import { Component } from '@angular/core';
import { ContactService } from '../../_services/contact.service';
import { ToastrService } from 'ngx-toastr';
import { TableModule } from "primeng/table";

@Component({
  selector: 'app-contacts',
  standalone: true,
  imports: [TableModule],
  templateUrl: './contacts.component.html',
  styleUrl: './contacts.component.css'
})
export class ContactsComponent {
  contactList: any = [];
  constructor(
    private contactService: ContactService,
    private toastR: ToastrService
  ) { }

  ngOnInit() {
    this.getContacts();
  }

  async getContacts() {
    try {
      let res: any = await this.contactService.getContacts().toPromise();
      if (res.length > 0) {
        this.contactList = res;
      }
      else {
        this.toastR.error('خطا در دریافت اطلاعات', 'خطا!');
      }
    }
    catch {
      this.toastR.error('خطا در دریافت اطلاعات', 'خطا!');
    }
  }
}
