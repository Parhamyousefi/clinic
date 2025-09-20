import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DropdownModule } from "primeng/dropdown";
import { ContactService } from '../../_services/contact.service';
import { SelectButtonModule } from 'primeng/selectbutton';
import { CommonModule } from '@angular/common';
import { MainService } from '../../_services/main.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-new-contact',
  standalone: true,
  imports: [DropdownModule, FormsModule, SelectButtonModule, CommonModule],
  templateUrl: './new-contact.component.html',
  styleUrl: './new-contact.component.css'
})
export class NewContactComponent {
  typesList: any = []
  selectedType: any;
  contactTypes: any = [];
  selectedContact: any;
  titleList: any[] = [
    { name: "جناب", code: "1" },
    { name: "دکتر", code: "2" },
    { name: "آقا", code: "3" },
    { name: "خانم", code: "4" },
    { name: "پروفسور", code: "5" },
    { name: "مهندس", code: "6" },
  ];
  selectedTitle: any;
  jobsList: any = [];
  newContactModel: any = [];
  countries: any = [];
  constructor(
    private contactService: ContactService,
    private mainService: MainService,
    private toastR: ToastrService
  ) { }

  ngOnInit() {
    this.getContactTypes();
    this.getJobs();
    this.getCountries();
  }

  async getContactTypes() {
    let res: any = await this.contactService.getContactTypes().toPromise();
    if (res.length > 0) {
      this.contactTypes = res;
      this.contactTypes.forEach(type => {
        type.value = type.id;
      });
    }

  }

  async getJobs() {
    let res: any = await this.mainService.getJobs().toPromise();
    if (res.length > 0) {
      this.jobsList = res;
      this.jobsList.forEach(job => {
        job.code = job.id
      });

    }
  }

  async getCountries() {
    let res: any = await this.mainService.getCountries().toPromise();
    if (res.length > 0) {
      this.countries = res;
      this.countries.forEach(country => {
        country.code = country.id
      });
    }
  }

  async saveContact() {
    try {
      let model = {
        "contactTypeId": this.newContactModel.selectedType,
        "titleId": this.newContactModel.selectedTitle.code,
        "firstName": this.newContactModel.firstName,
        "lastName": this.newContactModel.lastName,
        "preferredName": this.newContactModel.mainName,
        "occupation": null,
        "companyName": this.newContactModel.coName,
        "providerNumber": null,
        "email": this.newContactModel.email,
        "address1": this.newContactModel.address,
        "address2": null,
        "address3": null,
        "city": this.newContactModel.city,
        "state": null,
        "postCode": this.newContactModel.postalCode,
        "countryId": this.newContactModel.country.code,
        "notes": null,
        "jobId": this.newContactModel.selectedJob.code,
        "editOrNew": -1
      }
      let res: any = await this.contactService.saveContact(model).toPromise();
      if (res['status'] == 0) {
        this.toastR.success('با موفقیت ثبت شد');
      }
    }
    catch {
      this.toastR.error('لطفا مقادیر را به درستی وارد نمایید', 'خطا!')
    }
  }

}
