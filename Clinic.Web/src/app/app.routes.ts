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
import { PatientAppointmentsComponent } from './components/patient-appointments/patient-appointments.component';
import { PatientInfoComponent } from './components/patient-info/patient-info.component';
import { PatientAttachmentComponent } from './components/patient-attachment/patient-attachment.component';
import { ProductComponent } from './components/product/product.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ReceiptComponent } from './components/receipt/receipt.component';
import { ReceiptListComponent } from './components/receipt-list/receipt-list.component';
import { PatientTreatmentComponent } from './components/patient-treatment/patient-treatment.component';
import { PatientInvoiceComponent } from './components/patient-invoice/patient-invoice.component';

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
        path: 'new-invoice/:id/:type',
        component: NewInvoiceComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'new-contact/:id', component: NewContactComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'contacts', component: ContactsComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'patient/patientappointments/:id', component: PatientAppointmentsComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'patient/patient-info/:id', component: PatientInfoComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'patient/patient-attachment/:id', component: PatientAttachmentComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'product', component: ProductComponent,
        canActivate: [AuthGuard],
    },

    {
        path: 'product-list', component: ProductListComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'receipt', component: ReceiptComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'receipt-list', component: ReceiptListComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'payment-list', component: ReceiptListComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'patient/patient-treatment/:id', component: PatientTreatmentComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'payment', component: ReceiptComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'patient/patient-invoice/:id', component: PatientInvoiceComponent,
        canActivate: [AuthGuard]
    },
];
