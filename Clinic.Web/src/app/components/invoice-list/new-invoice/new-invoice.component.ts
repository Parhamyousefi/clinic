import { InvoiceService } from './../../../_services/invoice.service';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../_services/user.service';
import { SharedModule } from '../../../share/shared.module';
import { PatientService } from '../../../_services/patient.service';
import { InvoiceItemsComponent } from '../invoice-items/invoice-items.component';
import { ToastrService } from 'ngx-toastr';
import { firstValueFrom } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import moment from 'moment-jalaali';
import { MainService } from '../../../_services/main.service';

@Component({
  selector: 'app-new-invoice',
  standalone: true,
  imports: [SharedModule, InvoiceItemsComponent],
  templateUrl: './new-invoice.component.html',
  styleUrl: './new-invoice.component.css'
})
export class NewInvoiceComponent implements OnInit {

  constructor(
    private userService: UserService,
    private patientService: PatientService,
    private invoiceService: InvoiceService,
    private toastR: ToastrService,
    private activeRoute: ActivatedRoute,
    private router: Router,
    private mainService: MainService
  ) { }

  patientsList: any = [];
  selectedPatient: any;
  clinicsList: any = [];
  selectedClinic: any;
  editOrNew: number;
  selectedPatientAppointment: any = []
  hasInviceId: number;
  note: string;
  patientAppointmentsList: any = []
  type: any;
  selectedPatientTitle: any;
  selectedClinicTitle: any;
  selectedClinicId: any;
  patientId: any;

  async ngOnInit() {
    this.activeRoute.params.subscribe(async () => {
      this.selectedClinicId = +this.activeRoute.snapshot.paramMap.get('clinicId') || null;
      if (this.selectedClinicId) {
        this.patientId = this.activeRoute.snapshot.paramMap.get('id') || null;
      } else {
        this.editOrNew = +this.activeRoute.snapshot.paramMap.get('id') || null;
      }
      this.type = +this.activeRoute.snapshot.paramMap.get('type') || 2;

      await this.getPatients();
      if (this.patientId != null) {
        this.selectedPatient = this.patientsList.filter(patient => patient.id == this.patientId)[0];
      }
      await this.getClinics();
      if (this.selectedClinicId != null) {
        this.selectedClinic = this.clinicsList.filter(clinic => clinic.id == this.selectedClinicId)[0];
      }
      if (this.editOrNew != -1) {
        this.getInvoices();
        this.setSelectedPatient(this.editOrNew);
      }
    });


  }

  async getPatients() {
    try {
      let res: any = await this.patientService.getPatients().toPromise();
      if (res.length > 0) {
        this.patientsList = res;
        this.patientsList.forEach((patient: any) => {
          patient.name = patient.firstName + ' ' + patient.lastName;
          patient.code = patient.id;
        });
      }
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
    }
    catch { }
  }

  async saveInvoice() {
    if (!this.selectedPatient || !this.selectedClinic || !this.note || !this.selectedPatientAppointment) {
      this.toastR.error('خطا', 'مقادیر را وارد کنید');
      return
    }
    let model = {
      businessId: this.selectedClinic.code,
      patientId: this.selectedPatient.code,
      appointmentId: this.selectedPatientAppointment.code,
      notes: this.note,
      editOrNew: this.editOrNew
    }
    try {
      let res: any = await firstValueFrom(this.invoiceService.saveInvoice(model));
      if (res.status == 0) {
        this.toastR.success('با موفقیت ثبت شد!');
        if (this.editOrNew == -1) {
          const match = res.message.match(/Id\s*:\s*(\d+)/);
          const id = match ? parseInt(match[1], 10) : null;
          this.router.navigate(['/new-invoice/' + id + '/2']);
        }
      } else {
        this.toastR.error('خطا');
      }
    } catch (error) {
      this.toastR.error('خطا');
    }
  }



  async getPatientAppointments() {
    try {
      let res = await this.patientService.getPatientAppointments(this.selectedPatient.code).toPromise();
      this.patientAppointmentsList = res;
      this.patientAppointmentsList.forEach((item: any) => {
        item.code = item.id;
        let time = moment(item.start).format('HH:mm - jYYYY/jMM/jDD')
        item.name = time + " " + item.appointmentTypeName;
      });
    }
    catch { }
  }



  async getInvoices() {
    try {
      let res: any = await this.invoiceService.getInvoices().toPromise();
      let item = res.filter(x => x.id == this.editOrNew);
      this.selectedClinic = this.clinicsList.filter(x => x.id == item[0]['businessId'])[0];
      this.selectedClinicTitle = item[0]['businessName'];
      this.selectedPatient = this.patientsList.filter(x => x.id == item[0]['patientId'])[0];
      this.selectedPatientTitle = item[0]['patientName'];
      this.note = item[0]['notes'];
      await this.getPatientAppointments();
      this.selectedPatientAppointment = this.patientAppointmentsList.filter(x => x.id == item[0]['appointmentId'])[0];
    }
    catch { }
  }

  goToEditPage() {
    this.router.navigate(['/new-invoice/' + this.editOrNew + '/' + 2])
  }

  setSelectedPatient(patientId) {
    this.selectedPatient = this.patientsList.filter(patient => patient.id == patientId)[0];
  }
}
