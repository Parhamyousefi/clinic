import { Component } from '@angular/core';
import { PatientService } from '../../_services/patient.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';

import { CommonModule } from '@angular/common';
import moment from 'moment-jalaali';
import { TreatmentsService } from '../../_services/treatments.service';
import { SharedModule } from '../../share/shared.module';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
@Component({
  selector: 'app-patient-treatment',
  standalone: true,
  imports: [SharedModule, CommonModule],
  templateUrl: './patient-treatment.component.html',
  styleUrl: './patient-treatment.component.css'
})
export class PatientTreatmentComponent {
  patientName: string;
  selectedId: string;
  patientInfo: any = [];
  patientServiceList: any = [];
  questionsPerSectionList: any = [];
  patientServiceListTab: any = [];
  selectedService: any = null;
  public Editor = ClassicEditor;

  constructor(
    private patientService: PatientService,
    private toastR: ToastrService,
    private activeRoute: ActivatedRoute,
    private treatmentService: TreatmentsService
  ) { }

  ngOnInit() {
    this.selectedId = this.activeRoute.snapshot.paramMap.get('id');
    this.getPatientById();
    this.getPatientServices();
  }

  async getPatientById() {
    let res: any = await this.patientService.getPatientById(this.selectedId).toPromise();
    if (res.length > 0) {
      this.patientInfo = res[0];
      this.patientName = res[0].firstName + " " + res[0].lastName;
      const today = moment();
      const birth = moment(this.patientInfo.birthDate, 'jYYYY/jMM/jDD');
      this.patientInfo.age = today.diff(birth, 'years');
    }
  }


  async getPatientServices() {
    let res: any = await this.treatmentService.getPatientServices(this.selectedId).toPromise();
    this.patientServiceListTab = res;
    const grouped = Object.values(
      res.reduce((acc, item) => {
        const key = item.itemCategoryId;
        if (!acc[key]) {
          acc[key] = {
            id: item.itemCategoryId,
            name: item.itemCategoryName,
            values: []
          };
        }
        acc[key].values.push(item);
        return acc;
      }, {} as Record<number, { id: number; name: string; values: typeof res }>)
    );
    this.patientServiceList = grouped;
  }



  async getSectionPerService(id) {
    this.questionsPerSectionList = [];
    let res: any = await this.treatmentService.getSectionPerService(id).toPromise();
    await res.forEach(item => {
      this.treatmentService.getQuestionsPerSection(item.id).subscribe((res: any) => {
        res.forEach(question => {
          if (question.type == "MultiSelect" || question.type == "Check" || question.type == "Combo" || question.type == "Radio" || question.type == "textCombo") {
            this.treatmentService.getAnswersPerQuestion(question.id).subscribe(data => {
              question.answers = data;
            });
          }
        });
        this.questionsPerSectionList.push({
          id: item.id,
          name: item.title,
          values: res,
          isOpen: true
        });
      });
    });
    console.log(this.questionsPerSectionList);
  }


  onClick(event: MouseEvent, service, type) {
    event.stopPropagation();
    switch (type) {
      case 1:
        this.selectedService = service;
        this.getSectionPerService(service.treatmentTemplateId);
        break;
      case 2:
        break;

      default:
        break;
    }
  }


  onClickTab(event: MouseEvent, id, type) {
    event.stopPropagation();
    switch (type) {
      case 1:
        break;
      case 2:
        break;
      case 4:
        this.selectedService = null;
        break;
      default:
        break;
    }
  }


}