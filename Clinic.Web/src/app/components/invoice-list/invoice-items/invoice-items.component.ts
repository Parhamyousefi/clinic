import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../share/shared.module';
import { TreatmentsService } from './../../../_services/treatments.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-invoice-items',
  standalone: true,
  imports: [SharedModule, CommonModule],
  templateUrl: './invoice-items.component.html',
  styleUrl: './invoice-items.component.css'
})
export class InvoiceItemsComponent implements OnInit {

  constructor(
    private treatmentsService: TreatmentsService
  ) { }

  servicesList: any = [];
  selectedservice: any;
  type = 1;
  number: number;
  discount: any;
  price: any;
  amount: any;
  paymentType: any = null;
  ngOnInit(): void {
    this.getBillableItems();
  }

  async getBillableItems() {
    try {
      let res = await this.treatmentsService.getBillableItems().toPromise();
      this.servicesList = res;
      this.servicesList.forEach((service: any) => {
        service.code = service.id;
      });
    }
    catch { }
  }

  selectedItemMetod() {
    this.paymentType = null;
    this.number = null;
    this.discount = null;
    this.amount = null;
    this.price = this.selectedservice.price;
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



}
