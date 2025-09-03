import { ApplicationConfig, provideZoneChangeDetection, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';

import { provideAnimations } from '@angular/platform-browser/animations';
import { provideDateFnsAdapter } from 'ngx-material-date-fns-adapter';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { faIR } from 'date-fns/locale';

import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
export const appConfig: ApplicationConfig = {
  providers: [provideZoneChangeDetection({ eventCoalescing: true }), provideRouter(routes), provideHttpClient(), provideAnimations(),
  provideDateFnsAdapter(),
  { provide: MAT_DATE_LOCALE, useValue: faIR },
  importProvidersFrom(
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule
  ), provideAnimationsAsync()
  ]
};
