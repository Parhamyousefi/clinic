import { Component } from '@angular/core';
import { PatientService } from '../../_services/patient.service';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { DialogModule } from 'primeng/dialog';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { SharedModule } from 'primeng/api';

@Component({
  selector: 'app-patient-receipts',
  standalone: true,
  imports: [SharedModule, TableModule, FormsModule, DialogModule, CommonModule, RouterLink],
  templateUrl: './patient-receipts.component.html',
  styleUrl: './patient-receipts.component.css'
})
export class PatientReceiptsComponent {
  constructor(
    // private toastR: ToastrService,
    // private invoiceService: InvoiceService,
    private activeRoute: ActivatedRoute,
    private patientService: PatientService,
  ) { }
  pationId: any;
  patientRecceiptList:any = [];

  ngOnInit() {
    this.pationId = this.activeRoute.snapshot.paramMap.get('id');
    this.getPatientReceipts(this.pationId);
  }


  async getPatientReceipts(id) {
    let data = await this.patientService.getPatientReceipts(id).toPromise();
    this.patientRecceiptList = data;
  }
}
