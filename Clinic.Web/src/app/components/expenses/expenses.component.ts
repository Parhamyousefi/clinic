import { Component } from '@angular/core';
import { TableModule } from "primeng/table";
import { InvoiceService } from '../../_services/invoice.service';
import { DialogModule } from "primeng/dialog";
import { CommonModule } from '@angular/common';
import { DropdownModule } from "primeng/dropdown";
import { MainService } from '../../_services/main.service';
import { ToastrService } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';
import { SelectButtonModule } from 'primeng/selectbutton';

@Component({
  selector: 'app-expenses',
  standalone: true,
  imports: [TableModule, DialogModule, CommonModule, DropdownModule, FormsModule, SelectButtonModule],
  templateUrl: './expenses.component.html',
  styleUrl: './expenses.component.css'
})
export class ExpensesComponent {
  expensesList: any;
  showAddExpense: any;
  clinicsList: any;
  selectedClinic: any;
  newExpense: any = [];
  expenseStatus: any[] = [{ label: 'بله', value: '1' }, { label: 'خیر', value: '0' }];
  constructor(
    private invoiceService: InvoiceService,
    private mainService: MainService,
    private toastR: ToastrService
  ) { }

  ngOnInit() {
    this.getExpenses();
    this.getClinics();
  }


  async getExpenses() {
    let res: any = await this.invoiceService.getExpenses().toPromise();
    if (res.length > 0) {
      this.expensesList = res;
    }
  }

  async saveExpense() {
    try {
      let model = {
        "expenseNo": "string",
        "businessId": this.newExpense.selectedclinic.id,
        "expenseDate": this.newExpense.date,
        "vendor": this.newExpense.seller,
        "category": "string",
        "amount": 0,
        "tax": 0,
        "notes": "string",
        "editOrNew": -1
      }
      let res: any = await this.invoiceService.saveExpenses(model).toPromise();
    }
    catch { }
  }

  async getClinics() {
    try {
      let res = await this.mainService.getClinics().toPromise();
      this.clinicsList = res;
      this.clinicsList.forEach((clinic: any) => {
        clinic.code = clinic.id;
      });
      this.selectedClinic = this.clinicsList[0];
    }
    catch {
      this.toastR.error('خطا!', 'خطا در دریافت اطلاعات')
    }
  }

}
