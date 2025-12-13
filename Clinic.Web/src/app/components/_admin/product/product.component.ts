import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MainService } from '../../../_services/main.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {

  constructor(
    private mainService: MainService,
    private toastR: ToastrService

  ) { }
  newProductModel: any = [];
  ngOnInit() {
  }

  async saveProduct() {
    let model = {
      code: this.newProductModel.code,
      name: this.newProductModel.name,
      serialNumber: this.newProductModel.serialnumber,
      supplier: this.newProductModel.supplier,
      price: +this.newProductModel.price,
      stockLevel: +this.newProductModel.inventory,
      notes: this.newProductModel.note,
      isActive: this.newProductModel.isActive,
      editOrNew: -1
    }
    try {
      let data = await this.mainService.saveProduct(model).toPromise();
      if (data['status'] == 0) {
        this.toastR.success('با موفقیت ثبت شد!');
        this.newProductModel.code = null;
        this.newProductModel.name = null;
        this.newProductModel.serialnumber = null;
        this.newProductModel.supplier = null;
        this.newProductModel.pric = null;
        this.newProductModel.inventory = null;
        this.newProductModel.note = null;
        this.newProductModel.isActive = null;
      }
    } catch {
      this.toastR.error('خطا', 'خطا در انجام عملیات')
    }
  }
}
