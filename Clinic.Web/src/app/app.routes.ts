import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AppointmentComponent } from './components/appointment/appointment.component';
import { AuthGuard } from './auth.guard';
import { TodayAppointmentsComponent } from './components/today-appointments/today-appointments.component';
import { InvoiceListComponent } from './components/invoice-list/invoice-list.component';
import { NewInvoiceComponent } from './components/invoice-list/new-invoice/new-invoice.component';
import { PatientsComponent } from './components/patients/patients.component';
import { NewContactComponent } from './components/contacts/new-contact/new-contact.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { ProductComponent } from './components/product/product.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ReceiptComponent } from './components/receipt/receipt.component';

export const routes: Routes = [
    { path: '', component: LoginComponent },
    {
        path: 'appointment', component: AppointmentComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'today-appointment', component: TodayAppointmentsComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'patients', component: PatientsComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'invoice-list', component: InvoiceListComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'new-invoice', component: NewInvoiceComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'new-invoice/:id',
        component: NewInvoiceComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'new-contact', component: NewContactComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'contacts', component: ContactsComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'product', component: ProductComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'product-list', component: ProductListComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'receipt', component: ReceiptComponent,
        canActivate: [AuthGuard]
    },
];
