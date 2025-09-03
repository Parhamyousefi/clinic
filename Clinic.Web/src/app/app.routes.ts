import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AppointmentComponent } from './appointment/appointment.component';
import { TodayAppointmentsComponent } from './components/today-appointments/today-appointments.component';

export const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'dashboard', component: DashboardComponent },
    { path: 'appointment', component: AppointmentComponent },
    { path: 'today-appointment', component: TodayAppointmentsComponent },
];
