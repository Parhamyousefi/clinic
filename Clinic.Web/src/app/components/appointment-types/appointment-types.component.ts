import { Component } from '@angular/core';
import { MainService } from '../../_services/main.service';
import { TreatmentsService } from '../../_services/treatments.service';
import { DropdownModule } from "primeng/dropdown";
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../share/shared.module';
import { ColorPickerModule } from 'primeng/colorpicker';

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

  constructor(
    private treatmentService: TreatmentsService,
    private mainService: MainService
  ) { }

  ngOnInit() {
    this.getBillableItems();
    this.getTreatmentTemplate();
    this.getProducts();
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
}
