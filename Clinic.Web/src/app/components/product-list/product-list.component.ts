import { Component } from '@angular/core';
import { MainService } from '../../_services/main.service';
import { ToastrService } from 'ngx-toastr';
import { TableModule } from 'primeng/table';
import { FormsModule } from '@angular/forms';
import Swal from 'sweetalert2';
import { DialogModule } from 'primeng/dialog';
import { SharedModule } from 'primeng/api';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [SharedModule, TableModule, FormsModule, DialogModule, CommonModule],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent {

  constructor(
    private mainService: MainService,
    private toastR: ToastrService

  ) { }
  productsList: any = [];
  editProductModel: any = [];
  editProductModal: boolean = false;
  ngOnInit() {
    this.getProducts()
  }


  async getProducts() {
    let data = await this.mainService.getProducts().toPromise();
    this.productsList = data;
  }

  async deleteProduct(productId) {
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
          let data = await this.mainService.deleteProduct(productId).toPromise();
          if (data['status'] == 0) {
            this.toastR.success('با موفقیت حذف گردید');
            this.getProducts();
          }
        }
      }
      catch {
        this.toastR.error('خطایی رخ داد', 'خطا!')
      }
    })
  }
  openEditProduct(item) {
    this.editProductModal = true;
    this.editProductModel.code = item.code;
    this.editProductModel.name = item.name;
    this.editProductModel.serialnumber = item.serialNumber;
    this.editProductModel.supplier = item.supplier;
    this.editProductModel.price = item.price;
    this.editProductModel.inventory = item.stockLevel;
    this.editProductModel.note = item.notes;
    this.editProductModel.isActive = item.isActive;
    this.editProductModel.id = item.id;

  }
  async editProduct() {
    try {
      let model = {
        code: this.editProductModel.code,
        name: this.editProductModel.name,
        serialNumber: this.editProductModel.serialnumber,
        supplier: this.editProductModel.supplier,
        price: +this.editProductModel.price,
        stockLevel: +this.editProductModel.inventory,
        notes: this.editProductModel.note,
        isActive: this.editProductModel.isActive,
        editOrNew: this.editProductModel.id,
      }
      let data = await this.mainService.saveProduct(model).toPromise();
      if (data['status'] == 0) {
        this.toastR.success('با موفقیت ثبت شد!');
        this.editProductModel.code = null;
        this.editProductModel.name = null;
        this.editProductModel.serialnumber = null;
        this.editProductModel.supplier = null;
        this.editProductModel.pric = null;
        this.editProductModel.inventory = null;
        this.editProductModel.note = null;
        this.editProductModel.isActive = null;
        this.getProducts();
        this.editProductModal = false;
      }
    } catch {
      this.toastR.error('خطا', 'خطا در انجام عملیات')
    }
  }
  closeEditProductModal() {
    this.editProductModal = false;
  }
}
