import { Component } from '@angular/core';
import { PatientService } from '../../_services/patient.service';
import { ToastrService } from 'ngx-toastr';
import { UtilService } from '../../_services/util.service';
import { ActivatedRoute } from '@angular/router';
import { TableModule } from "primeng/table";
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../share/shared.module';
import { environment } from '../../../environments/environment';

export const ValidFormat = ['pdf', 'jpg', 'jpeg', 'png'];

@Component({
  selector: 'app-patient-attachment',
  standalone: true,
  imports: [TableModule, CommonModule, SharedModule],
  templateUrl: './patient-attachment.component.html',
  styleUrl: './patient-attachment.component.css'
})
export class PatientAttachmentComponent {
  fileToUpload: any;
  base64: any;
  fileName: any;
  fileType: any;
  patientId: string;
  patientAttachmentList: any;
  server: any;

  constructor(
    private patientService: PatientService,
    private toastR: ToastrService,
    private utilService: UtilService,
    private activeRoute: ActivatedRoute,
  ) {
    this.server = environment.url;
  }

  ngOnInit() {
    this.patientId = this.activeRoute.snapshot.paramMap.get('id');
    this.getAttachment();
  }


  handleFileInput(files: any) {
    let size = files[0].size;
    let type = files[0]['name'].split('.').pop();
    if (!ValidFormat.includes(type.toLowerCase())) {
      this.toastR.error("فرمت وارد شده معتبر نمی باشد.", "خطا");
      return;
    }
    if (size > 50000000) {
      this.toastR.error("حداکثر سایز فایل 50 مگابایت می باشد", "خطا");
      return;
    }
    this.fileToUpload = files.item(0);
    this.utilService.getBase64(files.item(0)).then((data) => {
      let base: any = data;
      this.base64 = base.split(',')[1];

      this.fileName = this.fileToUpload['name'];
      this.fileType = this.fileToUpload['name'].split('.').pop();
    });
  }

  async saveAttachment() {
    let model = {
      patientId: this.patientId,
      fileName: this.fileName,
      base64: this.base64,
      editOrNew: -1
    }
    let res: any = await this.patientService.saveAttachment(model).toPromise();
    if (res['status'] == 0) {
      this.toastR.success('با موفقیت ثبت شد');
    }
  }

  async getAttachment() {
    try {
      let res: any = await this.patientService.getAttachment(this.patientId).toPromise();
      if (res.length > 0) {
        this.patientAttachmentList = res;
        this.patientAttachmentList.forEach(attachment => {
          attachment.img = this.server + "/" + attachment.fileName;

        });
      }
    }
    catch {
      this.toastR.error('خطا!', 'خطا در دریافت اطلاعات')
    }
  }

  async deleteAttachment() {
    let res: any = await this.patientService.deleteAttachment().toPromise();
  }
}
