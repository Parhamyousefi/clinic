import { Component } from '@angular/core';
import { NgxMaterialTimepickerModule } from "ngx-material-timepicker";
import { SharedModule } from "../../share/shared.module";

@Component({
  selector: 'app-outinvoice-report',
  standalone: true,
  imports: [NgxMaterialTimepickerModule, SharedModule],
  templateUrl: './outinvoice-report.component.html',
  styleUrl: './outinvoice-report.component.css'
})
export class OutinvoiceReportComponent {
  selectedTimefrom: any;
  selectedDatefrom: any;
  selectedservice: any;
  servicesList: any;
  clinicsList: any;
  selectedClinic: any;
  visitStatusList: any;
  selectedStatus: any;
  onDateChange($event: any) {
    throw new Error('Method not implemented.');
  }
  selectedDateTo: any;
  selectedTimeTo: any;

}
