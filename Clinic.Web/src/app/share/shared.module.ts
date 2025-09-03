import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  NumberSplitPipe, ShamsiFullDatePipe, ShamsiDatePipe, ShamsiFullDateZonePipe,
  ShamsiFullDateZonePipeWithLine, ShamsiFullDateInOneLine, ShamsiFullDateInOneLineZone, JustTimePipe, inputNumberSplitPipe, TextSplit, CourseFilter,
  ShamsiUTCPipe, SafeSRCPipe, NumberSplitPricePipe, JustDatePipe, CustomTimePipe, ShamsiFullDateTicketPipe, ShamsiTimePipe, ConvertTimeSeconds,
  NumberSplitSlashPipe,
  NumberSplitDotPipe,
  ShamsiMonthPipe,
  PriceWithoutTaxPipe,
  JustDateZone
} from './custom.pipe';
import { MatDatepickerModulePersian } from 'ngx-persian-datepicker';
import { TableModule } from 'primeng/table';
import { FormsModule } from '@angular/forms';



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
    ConvertTimeSeconds,
    JustDateZone
  ],
  imports: [
    CommonModule,
    TableModule,
    FormsModule
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
    JustDateZone,
    TableModule,
    FormsModule
  ]
})
export class SharedModule { }
export { ShamsiUTCPipe };

