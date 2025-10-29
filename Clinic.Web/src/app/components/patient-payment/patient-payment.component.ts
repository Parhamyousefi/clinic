import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { PatientService } from '../../_services/patient.service';
import { TableModule } from 'primeng/table';
import { FormsModule } from '@angular/forms';
import { DialogModule } from 'primeng/dialog';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../share/shared.module';

@Component({
  selector: 'app-patient-payment',
  standalone: true,
  imports: [SharedModule, TableModule, FormsModule, DialogModule, CommonModule, RouterLink],
  templateUrl: './patient-payment.component.html',
  styleUrl: './patient-payment.component.css'
})
export class PatientPaymentComponent {
constructor(
    private activeRoute: ActivatedRoute,
    private patientService: PatientService,
    private router: Router,

  ) { }
  pationId: any;
  patientPaymentList: any = [];
  patientInfo: any = [];
  patientName: string;
  patientCode: string;


  async ngOnInit() {
    this.pationId = +this.activeRoute.snapshot.paramMap.get('id');
    await this.getPatientById();
    await this.getPatientPayments();
  }

  async getPatientPayments() {
    let data = await this.patientService.getPatientPayments(this.pationId).toPromise();
    this.patientPaymentList = data;
    if (this.patientPaymentList.length > 0) {
      this.patientPaymentList.forEach(element => {
        element.sumPrice = element.eftPos + element.cash;
      });
    }
  }

  async getPatientById() {
    let res: any = await this.patientService.getPatientById(this.pationId).toPromise();
    if (res.length > 0) {
      this.patientInfo = res[0];
      this.patientName = res[0].firstName + " " + res[0].lastName;
      this.patientCode = res[0].patientCode;
    }
  }

    ceatReceipt() {
    this.router.navigate(['/patient/receipt/' + this.pationId])
  }
}