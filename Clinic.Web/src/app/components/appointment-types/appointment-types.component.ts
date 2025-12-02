import { Component } from '@angular/core';
import { MainService } from '../../_services/main.service';
import { TreatmentsService } from '../../_services/treatments.service';
import { DropdownModule } from "primeng/dropdown";
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../share/shared.module';
import { ColorPickerModule } from 'primeng/colorpicker';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-appointment-types',
  standalone: true,
  imports: [DropdownModule, CommonModule, SharedModule, ColorPickerModule],
  templateUrl: './appointment-types.component.html',
  styleUrl: './appointment-types.component.css'
})
export class AppointmentTypesComponent {

  billableItems: any = [];
  newType: any = [];
  treatmentTypes: any = [];
  productList: any = [];
  appointmentTypes: any = [];

  constructor(
    private treatmentService: TreatmentsService,
    private mainService: MainService,
    private toastR: ToastrService
  ) { }

  ngOnInit() {
    this.getBillableItems();
    this.getTreatmentTemplate();
    this.getProducts();
    this.getAppointmentTypes();
  }
  async getBillableItems() {
    try {
      let res: any = await this.treatmentService.getBillableItems().toPromise();
      if (res.length > 0) {
        this.billableItems = res;
        this.billableItems.forEach((item: any) => {
          item.code = item.id,
            item.name = item.name
        });
      }
    }
    catch { }
  }

  async getTreatmentTemplate() {
    try {
      let model = {
        id: null
      }
      let res: any = await this.treatmentService.getTreatmentTemplates(model).toPromise();
      if (res.length > 0) {
        this.treatmentTypes = res;
        this.treatmentTypes.forEach((item: any) => {
          item.code = item.id,
            item.name = item.name
        });
      }
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

  async saveAppointmentType() {
    let model = {
      "name": this.newType.name,
      "description": this.newType.description,
      "duration": this.newType.duration,
      "relatedBillableItemId": this.newType.firstService.code,
      "relatedBillableItem2Id": this.newType.secondService.code,
      "relatedBillableItem3Id": this.newType.thirdService.code,
      "defaultTreatmentNoteTemplate": this.newType.treatmentType.code,
      "relatedProductId": this.newType.firstProduct.code,
      "relatedProduct2Id": this.newType.secondProduct.code,
      "relatedProduct3Id": this.newType.thirdProduct.code,
      "color": this.newType.typeColor,
      "showInOnlineBookings": this.newType.showInAppoinment,
      "editOrNew": -1
    }

    try {
      let res: any = this.treatmentService.saveAppointmentType(model).toPromise();
      if (res.status == 0) {
        this.toastR.success("یا موفقیت ذخیره شد!");
      }
    }
    catch { }
  }

  async getAppointmentTypes() {
    try {
      let res: any = await this.treatmentService.getAppointmentTypes().toPromise();
      if (res.length > 0) {
        this.appointmentTypes = res;
        console.log(this.appointmentTypes);

      }
    }
    catch {
      this.toastR.error('خطا!', 'خطا در دریافت اطلاعات')
    }
  }


}
