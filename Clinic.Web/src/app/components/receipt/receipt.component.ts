import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MainService } from '../../_services/main.service';
import { ToastrService } from 'ngx-toastr';
import { PatientService } from '../../_services/patient.service';
import { DropdownModule } from 'primeng/dropdown';
import { InvoiceService } from '../../_services/invoice.service';

@Component({
  selector: 'app-receipt',
  standalone: true,
  imports: [FormsModule, CommonModule, DropdownModule],
  templateUrl: './receipt.component.html',
  styleUrl: './receipt.component.css'
})
export class ReceiptComponent {

  constructor(
    private mainService: MainService,
    private toastR: ToastrService,
    private patientService: PatientService,
    private invoiceService: InvoiceService,

  ) { }
  receiptType: any = 0;
  newReceiptModel: any = [];
  patientsList: any;

  ngOnInit() {
    this.getPatients();
  }
  async getPatients() {
    try {
      let res: any = await this.patientService.getPatients().toPromise();
      if (res.length > 0) {
        this.patientsList = res;
        this.patientsList.forEach((patient: any) => {
          patient.name = patient.firstName + ' ' + patient.lastName;
          patient.code = patient.id;
        });
      }
    }
    catch {
      this.toastR.error('خطا!', 'خطا در دریافت اطلاعات')

    }
  }
  async savereceipt() {
    let model = {
      receiptNo: null,
      patientId: this.newReceiptModel.selectedPatient.code,
      cash: +this.newReceiptModel.cash,
      eftPos: this.newReceiptModel.eftPos,
      other: null,
      notes: this.newReceiptModel.note,
      allowEdit: true,
      receiptTypeId: this.receiptType ? 1 : 0
    }
    try {
      let data = await this.invoiceService.saveReceipt(model).toPromise();
      if (data['status'] == 0) {
        this.toastR.success('با موفقیت ثبت شد!');
        this.newReceiptModel.selectedPatient = null;
        this.newReceiptModel.Criticism = null;
        this.newReceiptModel.eftPos = null;
        this.newReceiptModel.note = null;
        this.newReceiptModel.cash = null;
        this.receiptType = 0;
      }
    } catch {
      this.toastR.error('خطا', 'خطا در انجام عملیات')
    }
  }

}
