import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { SharedModule } from 'primeng/api';
import { DialogModule } from 'primeng/dialog';
import { TableModule } from 'primeng/table';
import { MainService } from '../../_services/main.service';
import { ToastrService } from 'ngx-toastr';
import { InvoiceService } from '../../_services/invoice.service';

@Component({
  selector: 'app-receipt-list',
  standalone: true,
  imports: [SharedModule, TableModule, FormsModule, DialogModule, CommonModule, RouterLink],
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
  ngOnInit() {
    this.getReceipts()
  }

  async getReceipts() {
    let data = await this.invoiceService.getReceipts().toPromise();
    this.receiptsList = data;
    if(this.receiptsList.length>0){
      this.receiptsList.forEach(element => {
        element.sumPrice= element.eftPos + element.cash;
      });
    }
  }
}
