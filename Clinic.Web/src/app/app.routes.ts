import { Routes } from '@angular/router';
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
import { ExpensesComponent } from './components/expenses/expenses.component';
import { BusinessReportComponent } from './components/reports/business-report/business-report.component';
import { PatientReceiptsComponent } from './components/patient-receipts/patient-receipts.component';
import { PatientPaymentComponent } from './components/patient-payment/patient-payment.component';
import { LoginComponent } from './user-registration/login/login.component';
import { ChangePasswordComponent } from './user-registration/change-password/change-password.component';
import { OutinvoiceReportComponent } from './components/outinvoice-report/outinvoice-report.component';
import { NewUsersComponent } from './components/new-users/new-users.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { UserAppointmentSettingComponent } from './components/user-list/user-appointment-setting/user-appointment-setting.component';
import { BusinessListComponent } from './components/business-list/business-list.component';
import { NewBusinessComponent } from './components/business-list/new-business/new-business.component';

export const routes: Routes = [
    { path: '', component: LoginComponent },

    {
        path: 'change-password', component: ChangePasswordComponent,
        canActivate: [AuthGuard]
    },

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
        path: 'new-invoice/:invoiceId/:patientId/:clinicId/:appointmentId/:type',
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
        path: 'patient/appointments/:id', component: PatientAppointmentsComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'patient/info/:id', component: PatientInfoComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'patient/attachment/:id', component: PatientAttachmentComponent,
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
        path: 'receipt/:id', component: ReceiptComponent,
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
        path: 'patient/treatment/:id', component: PatientTreatmentComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'patient-treatment/:id', component: PatientTreatmentComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'payment', component: ReceiptComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'patient/invoice/:id', component: PatientInvoiceComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'patient/patient-receipts/:id', component: PatientReceiptsComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'patient/receipt/:id', component: ReceiptComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'patient/payment/:id', component: PatientPaymentComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'report/business-report', component: BusinessReportComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'outinvoice-report', component: OutinvoiceReportComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'user/new', component: NewUsersComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'userlist', component: UserListComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'userlist/user-appointment-setting/:uid', component: UserAppointmentSettingComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'business-List',
        component: BusinessListComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'new-business', component: NewBusinessComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'new-business/:id', component: NewBusinessComponent,
        canActivate: [AuthGuard]
    },



];
