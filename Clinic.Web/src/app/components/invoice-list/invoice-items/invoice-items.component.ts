import { MainService } from './../../../_services/main.service';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../share/shared.module';
import { TreatmentsService } from './../../../_services/treatments.service';
import { Component, Input, OnInit } from '@angular/core';
import { InvoiceService } from '../../../_services/invoice.service';
import { ToastrService } from 'ngx-toastr';
import { firstValueFrom } from 'rxjs';
@Component({
  selector: 'app-invoice-items',
  standalone: true,
  imports: [SharedModule, CommonModule],
  templateUrl: './invoice-items.component.html',
  styleUrl: './invoice-items.component.css'
})
export class InvoiceItemsComponent implements OnInit {

  constructor(
    private treatmentsService: TreatmentsService,
    private toastR: ToastrService,
    private invoiceService: InvoiceService,
    private mainService: MainService
  ) { }

  servicesList: any = [];
  selectedservice: any;
  type = 1;
  number: number;
  discount: any = null;
  price: any;
  amount: any;
  paymentType: any = null;
  editOrNew: boolean = false;
  @Input('invoiceId')
  set invoiceId(invoiceId: number) {
    if (invoiceId !== null) {
      this._invoiceId = invoiceId;
    }
  }
  _invoiceId: any;
  productList: any = [];
  selectedProduct: any;
  ngOnInit(): void {
    this.getBillableItems();
    this.getProducts();
  }

  async getBillableItems() {
    try {
      let res = await this.treatmentsService.getBillableItems().toPromise();
      this.servicesList = res;
      this.servicesList.forEach((item: any) => {
        item.code = item.id;
      });
    }
    catch { }
  }


  async getProducts() {
    try {
      let res = await this.mainService.getProducts().toPromise();
      this.productList = res;
      this.productList.forEach((item: any) => {
        item.code = item.id;
      });
    }
    catch { }
  }

  hadelType(type) {
    this.type = type;
    this.paymentType = null;
    this.number = null;
    this.discount = null;
    this.amount = null;
  }

  selectedItemMetod() {
    this.paymentType = null;
    this.number = null;
    this.discount = null;
    this.amount = null;
    if (this.type == 1) {
      this.price = this.selectedservice.price;
    } else {
      this.price = this.selectedProduct.price;
    }
  }

  handelPrice() {
    this.amount = null;
    if (this.paymentType == null) {
      return
    } else {
      let totalPrice = (+this.number * +this.price);
      switch (this.paymentType) {
        case '1':
          this.amount = totalPrice - +this.discount;
          break;
        case '2':
          this.amount = totalPrice - (totalPrice * +this.discount / 100);
          break;
      }
    }
  }



  async saveInvoiceItem() {
    if (!this.number || this.discount == null || !this.paymentType || (!this.selectedservice && this.type == 1) || (this.type == 2 && !this.selectedProduct)) {
      this.toastR.error('خطا', 'مقادیر را وارد کنید');
      return
    }
    let model = {
      invoiceId: this._invoiceId,
      itemId: this.type == 1 ? this.selectedservice.code : null,
      productId: this.type == 2 ? this.selectedProduct.code : null,
      quantity: this.number,
      discount: this.discount,
      discountTypeId: this.paymentType,
      editOrNew: this.editOrNew ? 1 : -1
    }
    try {
      let res: any = await firstValueFrom(this.invoiceService.saveInvoiceItem(model));
      if (res.status == 0) {
        this.toastR.success('با موفقیت ثبت شد!');
        this.paymentType = null;
        this.number = null;
        this.discount = null;
        this.amount = null;
      } else {
        this.toastR.error('خطا');
      }
    } catch (error) {
      this.toastR.error('خطا');
    }
  }



}
