import { Injectable, Optional, Inject } from '@angular/core';
import { DateAdapter, MAT_DATE_LOCALE } from '@angular/material/core';
import moment from 'moment-jalaali';

moment.loadPersian({ dialect: 'persian-modern', usePersianDigits: false });

@Injectable()
export class JalaliMomentDateAdapter extends DateAdapter<moment.Moment> {
    constructor(@Optional() @Inject(MAT_DATE_LOCALE) matDateLocale: string) {
        super();
        this.setLocale(matDateLocale || 'fa');
    }

    setLocale(locale: string): void {
        super.setLocale(locale);
        moment.locale(locale || 'fa');
    }

    getYear(date: moment.Moment): number {
        return date.jYear();
    }

    getMonth(date: moment.Moment): number {
        return date.jMonth();
    }

    getDayOfWeek(date: moment.Moment): number {
        const day = date.day(); // میلادی: یکشنبه = 0، شنبه = 6
        return (day + 1) % 7;
    }

    getFirstDayOfWeek(): number {
        return 0; // شنبه
    }


    getDate(date: moment.Moment): number {
        return date.jDate();
    }




    getMonthNames(style: 'long' | 'short' | 'narrow'): string[] {
        return ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور',
            'مهر', 'آبان', 'آذر', 'دی', 'بهمن', 'اسفند'];
    }

    getDateNames(): string[] {
        return Array.from({ length: 31 }, (_, i) => String(i + 1));
    }

    getDayOfWeekNames(style: 'long' | 'short' | 'narrow'): string[] {
        return ['شنبه', 'یکشنبه', 'دوشنبه', 'سه‌شنبه', 'چهارشنبه', 'پنجشنبه', 'جمعه'];
    }

    getYearName(date: moment.Moment): string {
        return String(date.jYear());
    }

    getNumDaysInMonth(date: moment.Moment): number {
        return date.daysInMonth();
    }

    clone(date: moment.Moment): moment.Moment {
        return date.clone();
    }

    createDate(year: number, month: number, date: number): moment.Moment {
        return moment(`${year}/${month + 1}/${date}`, 'jYYYY/jMM/jDD')
            .startOf('day')
            .utcOffset('+03:30', true);
    }

    today(): moment.Moment {
        return moment().subtract(2, 'day').startOf('day').utcOffset('+03:30', true);
    }


    parse(value: any, parseFormat: string | string[]): moment.Moment | null {
        if (value && typeof value === 'string') {
            const date = moment(value, parseFormat, this.locale, true);
            return date.isValid() ? date : null;
        }
        return value ? moment(value) : null;
    }

    format(date: moment.Moment, displayFormat: string): string {
        return date.format(displayFormat);
    }

    addCalendarYears(date: moment.Moment, years: number): moment.Moment {
        return date.clone().add(years, 'jYear');
    }

    addCalendarMonths(date: moment.Moment, months: number): moment.Moment {
        return date.clone().add(months, 'jMonth');
    }

    addCalendarDays(date: moment.Moment, days: number): moment.Moment {
        return date.clone().add(days, 'day');
    }

    toIso8601(date: moment.Moment): string {
        return date.clone().locale('en').format('YYYY-MM-DD');
    }

    isDateInstance(obj: any): boolean {
        return moment.isMoment(obj);
    }

    isValid(date: moment.Moment): boolean {
        return date.isValid();
    }

    invalid(): moment.Moment {
        return moment.invalid();
    }

    compareDate(first: moment.Moment, second: moment.Moment): number {
        const f = first.clone().startOf('day');
        const s = second.clone().startOf('day');
        return f.isBefore(s) ? -1 : f.isAfter(s) ? 1 : 0;
    }

    sameDate(first: moment.Moment, second: moment.Moment): boolean {
        return first.isSame(second, 'day');
    }

    getISODateString(date: moment.Moment): string {
        return date.toISOString();
    }
}
