import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { PatientService } from '../../_services/patient.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { PdfMakerComponent } from '../../share/pdf-maker/pdf-maker.component';

@Component({
  selector: 'app-patient-info',
  standalone: true,
  imports: [CommonModule,PdfMakerComponent],
  templateUrl: './patient-info.component.html',
  styleUrl: './patient-info.component.css'
})
export class PatientInfoComponent {
  patientName: string;
  selectedEditContactId: string;
  patientInfo: any = [];
  constructor(
    private patientService: PatientService,
    private toastR: ToastrService,
    private activeRoute: ActivatedRoute,
  ) { }

  ngOnInit() {
    this.selectedEditContactId = this.activeRoute.snapshot.paramMap.get('id');
    this.getPatientById(this.selectedEditContactId);
  }

  async getPatientById(patientId) {
    try {
      let res: any = await this.patientService.getPatientById(patientId).toPromise();
      if (res.length > 0) {
        this.patientInfo = res[0];
        this.patientName = res[0].firstName + " " + res[0].lastName;
      }
    }
    catch {
      this.toastR.error('خطا!', 'خطا در دریافت اطلاعات')
    }
  }

}
