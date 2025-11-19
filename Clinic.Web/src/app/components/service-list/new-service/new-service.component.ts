import { AfterViewInit, Component } from '@angular/core';
import { TreatmentsService } from '../../../_services/treatments.service';
import { SharedModule } from '../../../share/shared.module';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { firstValueFrom } from 'rxjs';
import { ColorPickerModule } from 'primeng/colorpicker';

@Component({
  selector: 'app-new-service',
  standalone: true,
  imports: [SharedModule, ColorPickerModule],
  templateUrl: './new-service.component.html',
  styleUrl: './new-service.component.css'
})
export class NewServiceComponent implements AfterViewInit {

  constructor(
    private treatmentsService: TreatmentsService,
    private activeRoute: ActivatedRoute,
    private toastR: ToastrService,
    private router: Router

  ) { }

  model: any = [];
  serviceList: any = [];
  editOrNew: number;
  treatmentList: any = [];
  itemCategory: any = [];

  async ngAfterViewInit(): Promise<void> {
    this.editOrNew = +this.activeRoute.snapshot.paramMap.get('id') || -1;
    this.getItemCategory();
    if (this.editOrNew != -1) {
      await this.getBillableItems();
    }
  }

  async saveBillableItem() {
    let model =
    {
      code: this.model.code,
      name: this.model.name,
      price: +this.model.price,
      isOther: null,
      itemTypeId: 0,
      duration: this.model.duration,
      allowEditPrice: this.model.allowEditPrice,
      treatmentTemplateId: this.model.treatmentTemplateId,
      forceOneInvoice: this.model.forceOneInvoice,
      isTreatmentDataRequired: this.model.isTreatmentDataRequired,
      "group": "string",
      parentId: this.model.parentId,
      itemCategoryId: this.model.itemCategoryId,
      orderInItemCategory: this.model.orderInItemCategory,
      autoCopyTreatment: this.model.autoCopyTreatment,
      discountPercent: null,
      needAccept: this.model.needAccept,
      lastTimeColor: this.model.lastTimeColor,
      editOrNew: this.editOrNew
    }
    try {
      let res: any = await firstValueFrom(this.treatmentsService.saveBillableItem(model));
      if (res.status == 0) {
        this.toastR.success('با موفقیت ثبت شد!');
        this.router.navigate(['/business-List']);
      } else {
        this.toastR.error('خطا');
      }
    } catch (error) {
      this.toastR.error('خطا');
    }
  }

  async getBillableItems() {
    try {
      let res: any = await this.treatmentsService.getBillableItems().toPromise();
      let item = res.filter(x => x.id == this.editOrNew);
      this.model.name = item[0]['name'];
      this.model.code = item[0]['name'];
      this.model.price = item[0]['name'];
      this.model.duration = item[0]['name'];
      this.model.allowEditPrice = item[0]['name'];
      this.model.forceOneInvoice = item[0]['name'];
      this.model.treatmentTemplateId = item[0]['name'];
      this.model.isTreatmentDataRequired = item[0]['name'];
      this.model.parentId = item[0]['name'];
      this.model.itemCategoryId = item[0]['name'];
      this.model.orderInItemCategory = item[0]['name'];
      this.model.autoCopyTreatment = item[0]['name'];
      this.model.needAccept = item[0]['name'];
    }
    catch { }
  }


  async getItemCategory() {
    let res: any = await this.treatmentsService.getItemCategory().toPromise();
    this.itemCategory = res;
  }

}