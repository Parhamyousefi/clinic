import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  NumberSplitPipe, ShamsiFullDatePipe, ShamsiDatePipe, ShamsiFullDateZonePipe,
  ShamsiFullDateZonePipeWithLine, ShamsiFullDateInOneLine, ShamsiFullDateInOneLineZone, JustTimePipe, inputNumberSplitPipe, TextSplit, CourseFilter,
  ShamsiUTCPipe, SafeSRCPipe, NumberSplitPricePipe, JustDatePipe, CustomTimePipe, ShamsiFullDateTicketPipe, ShamsiTimePipe, ConvertTimeSeconds,
  NumberSplitSlashPipe,
  NumberSplitDotPipe,
  ShamsiMonthPipe,
  PriceWithoutTaxPipe
} from './custom.pipe';


@NgModule({
  declarations: [
    NumberSplitPipe,
    PriceWithoutTaxPipe,
    ShamsiFullDatePipe,
    ShamsiFullDateInOneLine,
    ShamsiFullDateInOneLineZone,
    ShamsiFullDateTicketPipe,
    ShamsiDatePipe,
    ShamsiUTCPipe,
    ShamsiFullDateZonePipe,
    ShamsiFullDateZonePipeWithLine,
    ShamsiMonthPipe,
    inputNumberSplitPipe,
    TextSplit,
    CourseFilter,
    JustTimePipe,
    SafeSRCPipe,
    JustDatePipe,
    NumberSplitPricePipe,
    CustomTimePipe,
    ShamsiTimePipe,
    NumberSplitDotPipe,
    NumberSplitSlashPipe,
    ConvertTimeSeconds
  ],
  imports: [
    CommonModule,
  ],
  exports: [
    NumberSplitPipe,
    ShamsiFullDatePipe,
    PriceWithoutTaxPipe,
    ShamsiFullDateInOneLine,
    ShamsiFullDateInOneLineZone,
    ShamsiFullDateTicketPipe,
    ShamsiUTCPipe,
    ShamsiDatePipe,
    ShamsiFullDateZonePipe,
    ShamsiFullDateZonePipeWithLine,
    ShamsiMonthPipe,
    CourseFilter,
    SafeSRCPipe,
    JustTimePipe,
    JustDatePipe,
    TextSplit,
    inputNumberSplitPipe,
    NumberSplitPricePipe,
    CustomTimePipe,
    ShamsiTimePipe,
    NumberSplitSlashPipe,
    NumberSplitDotPipe,
    ConvertTimeSeconds,
  ]
})
export class SharedModule { }
