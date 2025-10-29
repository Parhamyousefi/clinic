import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DropdownModule } from "primeng/dropdown";
import { ContactService } from '../../../_services/contact.service';
import { SelectButtonModule } from 'primeng/selectbutton';
import { CommonModule } from '@angular/common';
import { MainService } from '../../../_services/main.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { timeout } from 'rxjs';

@Component({
  selector: 'app-new-contact',
  standalone: true,
  imports: [DropdownModule, FormsModule, SelectButtonModule, CommonModule, RouterLink],
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
  selectedEditContactId: any;
  editMode: boolean;
  selectedEditContact: any;
  isCurrentUrl: any;
  @Output() closeModal = new EventEmitter<any>();

  constructor(
    private contactService: ContactService,
    private mainService: MainService,
    private toastR: ToastrService,
    private router: Router,
    private activeRoute: ActivatedRoute,

  ) {
  }

  ngOnInit() {
    if (this.router.url.startsWith('/new-contact')) {
      this.isCurrentUrl = true;
      this.selectedEditContactId = this.activeRoute.snapshot.paramMap.get('id');
    } else {
      this.isCurrentUrl = false;
      this.selectedEditContactId = -1
    }

    // this.getContactData();
    this.getContactTypes();
    this.getJobs();
    this.getCountries();
    if(this.selectedEditContactId != -1){
      this.editSelectedContact(this.selectedEditContactId);
    }
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
        "contactTypeId": this.newContactModel.selectedType || null,
        "titleId": this.newContactModel.selectedTitle?.code || null,
        "firstName": this.newContactModel.firstName || null,
        "lastName": this.newContactModel.lastName || null,
        "preferredName": this.newContactModel.mainName || null,
        "occupation": null,
        "companyName": this.newContactModel.coName || null,
        "providerNumber": null,
        "email": this.newContactModel.email || null,
        "address1": this.newContactModel.address || null,
        "address2": null,
        "address3": null,
        "city": this.newContactModel.city || null,
        "state": null,
        "postCode": this.newContactModel.postalCode || null,
        "countryId": this.newContactModel.country?.code || null,
        "notes": null,
        "jobId": this.newContactModel.selectedJob?.code || null,
        "editOrNew": this.selectedEditContactId 
      }
      let res: any = await this.contactService.saveContact(model).toPromise();
      if (res['status'] == 0) {
        this.toastR.success('با موفقیت ثبت شد');
        if (this.isCurrentUrl) {
          this.router.navigate(['/contacts']);
        } else {
          this.close(model);
        }
      }
    }
    catch {
      this.toastR.error('لطفا مقادیر را به درستی وارد نمایید', 'خطا!')
    }
  }

  async editSelectedContact(id) {
    let res: any = await this.contactService.getContacts().toPromise();
    if (res.length > 0) {
      let contacts = res;
      let selectedEditContact = contacts.filter((contact: any) => contact.id == id)[0];

      this.newContactModel.selectedType = this.contactTypes.filter(type => type.id == selectedEditContact.contactTypeId)[0].value;
      this.newContactModel.selectedTitle = this.titleList.filter(title => title.code == selectedEditContact.titleId)[0];
      this.newContactModel.firstName = selectedEditContact.firstName;
      this.newContactModel.lastName = selectedEditContact.lastName;
      this.newContactModel.mainName = selectedEditContact.preferredName;
      this.newContactModel.coName = selectedEditContact.companyName;
      this.newContactModel.email = selectedEditContact.email;
      this.newContactModel.address = selectedEditContact.address1;
      this.newContactModel.city = selectedEditContact.city;
      this.newContactModel.postalCode = selectedEditContact.postCode;
      this.newContactModel.country = this.countries.filter(country => country.id == selectedEditContact.jobId)[0];
      this.newContactModel.selectedJob = this.jobsList.filter(job => job.id == selectedEditContact.countryId)[0];
    }
  }

  close(modal) {
    this.closeModal.emit(modal);
  }


}
