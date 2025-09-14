import { ApplicationConfig, provideZoneChangeDetection, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import { MAT_DATE_FORMATS, MAT_DATE_LOCALE, DateAdapter } from '@angular/material/core';

import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideToastr } from 'ngx-toastr';
import { JalaliMomentDateAdapter } from './share/jalali-date-adapter';
import moment from 'moment-jalaali';

export const PERSIAN_DATE_FORMATS = {
  parse: {
    dateInput: 'jYYYY/jMM/jDD',
  },
  display: {
    dateInput: 'jYYYY/jMM/jDD',
    monthYearLabel: 'jMMMM jYYYY',
    dateA11yLabel: 'jYYYY/jMM/jDD',
    monthYearA11yLabel: 'jMMMM jYYYY',
  },
};

moment.loadPersian({ dialect: 'persian-modern', usePersianDigits: false });

const miladiDate = moment('2025-09-01T00:00:00'); // 👈 ساعت صفر
const jalaliDate = miladiDate
  .utcOffset('+03:30', true) // 👈 تایم‌زون ایران
  .startOf('day')            // 👈 حذف ساعت
  .format('jYYYY/jMM/jDD');
console.log('تاریخ شمسی دقیق:', jalaliDate);

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(),
    provideAnimations(),
    { provide: DateAdapter, useClass: JalaliMomentDateAdapter },
    { provide: MAT_DATE_FORMATS, useValue: PERSIAN_DATE_FORMATS },
    { provide: MAT_DATE_LOCALE, useValue: 'fa' },
    importProvidersFrom(
      MatDatepickerModule,
      MatFormFieldModule,
      MatInputModule
    ),
    provideAnimationsAsync(),
    provideToastr(),
    JalaliMomentDateAdapter
  ]
};
