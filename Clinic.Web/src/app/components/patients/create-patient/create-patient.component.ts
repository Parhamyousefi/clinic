import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SelectButtonModule } from "primeng/selectbutton";
import { InputMaskModule } from 'primeng/inputmask';
import { PatientService } from '../../../_services/patient.service';
import { Router } from '@angular/router';
import { DropdownModule } from 'primeng/dropdown';
import { MainService } from '../../../_services/main.service';
import { ContactService } from '../../../_services/contact.service';
@Component({
  selector: 'app-create-patient',
  standalone: true,
  imports: [SelectButtonModule, FormsModule, InputMaskModule, DropdownModule],
  templateUrl: './create-patient.component.html',
  styleUrl: './create-patient.component.css'
})
export class CreatePatientComponent {
  constructor(
    private patientService: PatientService,
    private router: Router,
    private mainService: MainService,
    private contactService: ContactService
  ) {
  }

  ngOnInit() {
  }



}
