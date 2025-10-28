import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import swal from 'sweetalert2';
import { PdfMakerComponent } from '../../share/pdf-maker/pdf-maker.component';
import { PatientService } from '../../_services/patient.service';
import { Router, RouterLink } from '@angular/router';
import { MainService } from '../../_services/main.service';
import { FormsModule } from '@angular/forms';

export interface imenu {
  id: number;
  text: string;
  link: string;
  roleAccess: number[];
  icon: string;
}


export const PatientMenu: imenu[] = [
  { id: 0, text: "اطلاعات بیمار", link: '/patient/info', roleAccess: [], icon: '' },
  { id: 1, text: "پرونده بالینی", link: '/patient/treatment', roleAccess: [], icon: '' },
  { id: 2, text: "پیوست ها", link: '/patient/attachment', roleAccess: [], icon: '' },
  { id: 3, text: "وقت ها", link: '/patient/appointments', roleAccess: [], icon: '' },
  { id: 4, text: "صورتحساب ها", link: '/patient/invoice', roleAccess: [], icon: '' },
  { id: 5, text: "دریافت ها", link: '/patient/receipt', roleAccess: [], icon: '' },
  { id: 6, text: "پرداخت ها", link: '/patient/payment', roleAccess: [], icon: '' },
  { id: 7, text: "پیامک ها", link: '/', roleAccess: [], icon: '' },
];


@Component({
  selector: 'app-patient-menu',
  standalone: true,
  imports: [PdfMakerComponent, RouterLink, CommonModule, FormsModule],
  templateUrl: './patient-menu.component.html',
  styleUrl: './patient-menu.component.css'
})
export class PatientMenuComponent {
  isMobileSize: boolean;
  sidebarMenu: any;
  patientMenu: imenu[];
  hasPatientMenu: boolean;
  patientId: string;
  patientInfo: any;
  patientName: any;
  selectedSideBarItem: any;
  patientNote: any;
  patientsNote: any;
  openNoteInput: any;
  noteEdit: boolean;
  noteId: any;
  hoveredNote: any;
  constructor(
    private toastR: ToastrService,
    private patientService: PatientService,
    private router: Router,
    private mainService: MainService,
  ) { }
  ngOnInit() {
    this.noteId = -1;
    let url = location.pathname;
    this.isMobileSize = window.innerWidth <= 768 && window.innerHeight <= 1024;
    this.patientMenu = PatientMenu;
    if ((url.startsWith('/patient/'))) {
      this.hasPatientMenu = true;
      this.patientId = url.split('/').pop();
      this.getPatientById(this.patientId);
      this.getNotes();
    }
  }
  async getPatientById(patientId) {
    try {
      let res: any = await this.patientService.getPatientById(patientId).toPromise();
      if (res.length > 0) {
        this.patientInfo = res[0]
        this.patientName = res[0].firstName + " " + res[0].lastName;
      }
    }
    catch {
      this.toastR.error('خطا!', 'خطا در دریافت اطلاعات');
    }
  }

  async deletePatient(patientId) {
    swal.fire({
      title: "آیا از حذف این بیمار مطمئن هستید ؟",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "بله انجام بده",
      cancelButtonText: "منصرف شدم",
      reverseButtons: false,
    }).then(async (result) => {
      try {
        if (result.value) {
          let res: any = await this.patientService.deletePatient(patientId).toPromise();
          if (res['status'] == 0) {
            this.toastR.success('با موفقیت حذف گردید');
            this.router.navigate(['/patients']);
          }
        }
      }
      catch {
        this.toastR.error('خطایی رخ داد', 'خطا!')
      }
    })
  }

  async saveNote() {
    try {
      if (this.patientNote.length > 0) {
        let model = {
          "message": this.patientNote,
          "patientId": this.patientId,
          "editOrNew": this.noteId,
          "orderOf": 0
        }
        let res: any = await this.mainService.saveNote(model).toPromise();
        if (res['status'] == 0) {
          this.toastR.success('با موفقیت ذخیره گردید');
          this.patientNote = "";
          this.noteId = -1
          this.openNoteInput = false;
          this.getNotes();
        }
      }
    }
    catch { }
  }

  async getNotes() {
    try {
      let res: any = await this.mainService.getNotes(this.patientId).toPromise();
      if (res.length > 0) {
        this.patientsNote = res;
      }
    }
    catch { }
  }

  editNote(note) {
    this.openNoteInput = true;
    this.patientNote = note.note;
    this.noteId = note.noteId;
  }

  async deleteNote(event, id) {
    event.stopPropagation();
    swal.fire({
      title: "آیا از حذف این یادداشت مطمئن هستید ؟",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "بله انجام بده",
      cancelButtonText: "منصرف شدم",
      reverseButtons: false,
    }).then(async (result) => {
      try {
        if (result.value) {
          let res: any = await this.mainService.deleteNote(id).toPromise();
          if (res['status'] == 0) {
            this.toastR.success('با موفقیت ذخیره گردید');
            this.getNotes();
          }
        }
      }
      catch { }
    })
  }
}
