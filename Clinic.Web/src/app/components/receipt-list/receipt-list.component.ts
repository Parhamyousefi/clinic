import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { SharedModule } from "../../share/shared.module";
import { DialogModule } from 'primeng/dialog';
import { TableModule } from 'primeng/table';
import { MainService } from '../../_services/main.service';
import { ToastrService } from 'ngx-toastr';
import { InvoiceService } from '../../_services/invoice.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-receipt-list',
  standalone: true,
  imports: [SharedModule, CommonModule, TableModule, FormsModule, DialogModule, RouterLink],
  templateUrl: './receipt-list.component.html',
  styleUrl: './receipt-list.component.css'
})
export class ReceiptListComponent {
  constructor(
    private mainService: MainService,
    private toastR: ToastrService,
    private invoiceService: InvoiceService,
    private activeRoute: ActivatedRoute
  ) { }
  receiptsList: any = [];
  editReceiptsModel: any = [];
  showReceiptsModal: boolean = false;
  patientId: any;
  receiptType: any = 0;

  ngOnInit() {
    this.getReceipts()
  }

  async getReceipts() {
    let data = await this.invoiceService.getReceipts().toPromise();
    this.receiptsList = data;
    if (this.receiptsList.length > 0) {
      this.receiptsList.forEach(element => {
        element.sumPrice = element.eftPos + element.cash;
      });
    }
  }
  async deleteReceipt(id) {
    Swal.fire({
      title: "آیا از حذف مطمئن هستید ؟",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "بله انجام بده",
      cancelButtonText: "منصرف شدم",
      reverseButtons: false,
    }).then(async (result) => {
      try {
        if (result.value) {
          let data = await this.invoiceService.deleteReceipt(id).toPromise();
          if (data['status'] == 0) {
            this.toastR.success('با موفقیت حذف گردید');
            this.getReceipts();
          }
        }
      }
      catch {
        this.toastR.error('خطایی رخ داد', 'خطا!')
      }
    })
  }
  openEditreceipt(item) {
    this.editReceiptsModel.name = item.patientName;
    this.editReceiptsModel.patientId = item.patientId;
    this.editReceiptsModel.cash = item.cash;
    this.editReceiptsModel.eftPos = item.eftPos;
    this.editReceiptsModel.note = item.notes;
    this.receiptType = item.receiptTypeId ? 1 : 0;
    this.editReceiptsModel.sum = item.cash + item.eftPos;
    this.showReceiptsModal = true;
  }

  async editreceipt() {
    let model = {
      receiptNo: null,
      patientId: this.editReceiptsModel.patientId,
      cash: +this.editReceiptsModel.cash,
      eftPos: this.editReceiptsModel.eftPos,
      other: null,
      notes: this.editReceiptsModel.note,
      allowEdit: true,
      receiptTypeId: this.receiptType ? 1 : 0
    }
    try {
      let data = await this.invoiceService.saveReceipt(model).toPromise();
      if (data['status'] == 0) {
        this.toastR.success('با موفقیت ثبت شد!');
        this.closeeditReceiptsModel();
        this.getReceipts();
      }
    } catch {
      this.toastR.error('خطا', 'خطا در انجام عملیات')
    }
  }
  closeeditReceiptsModel() {
    this.editReceiptsModel.name = null;
    this.editReceiptsModel.patientId = null;
    this.editReceiptsModel.cash = null;
    this.editReceiptsModel.eftPos = null;
    this.editReceiptsModel.note = null;
    this.receiptType = 0;
    this.editReceiptsModel.sum = null;
    this.showReceiptsModal = false;
  }
  sumNumber() {
    this.editReceiptsModel.sum = (this.editReceiptsModel.eftPos | 0) + (this.editReceiptsModel.cash | 0);
  }
}
