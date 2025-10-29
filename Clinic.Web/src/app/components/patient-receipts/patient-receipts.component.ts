import { Component } from '@angular/core';
import { PatientService } from '../../_services/patient.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { DialogModule } from 'primeng/dialog';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { SharedModule } from '../../share/shared.module';

@Component({
  selector: 'app-patient-receipts',
  standalone: true,
  imports: [SharedModule, TableModule, FormsModule, DialogModule, CommonModule, RouterLink],
  templateUrl: './patient-receipts.component.html',
  styleUrl: './patient-receipts.component.css'
})
export class PatientReceiptsComponent {
  constructor(
    private activeRoute: ActivatedRoute,
    private patientService: PatientService,
    private router: Router,

  ) { }
  pationId: any;
  patientRecceiptList: any = [];
  patientInfo: any = [];
  patientName: string;
  patientCode: string;


  async ngOnInit() {
    this.pationId = +this.activeRoute.snapshot.paramMap.get('id');
    await this.getPatientReceipts();
    await this.getPatientById();
  }

  async getPatientById() {
    let res: any = await this.patientService.getPatientById(this.pationId).toPromise();
    if (res.length > 0) {
      this.patientInfo = res[0];
      this.patientName = res[0].firstName + " " + res[0].lastName;
      this.patientCode = res[0].patientCode;
    }
  }

  async getPatientReceipts() {
    let data = await this.patientService.getPatientReceipts(this.pationId).toPromise();
    this.patientRecceiptList = data;
    if (this.patientRecceiptList.length > 0) {
      this.patientRecceiptList.forEach(element => {
        element.sumPrice = element.eftPos + element.cash;
      });
    }
  }
  ceatReceipt() {
    this.router.navigate(['/patient/receipt/' + this.pationId])
  }
}
