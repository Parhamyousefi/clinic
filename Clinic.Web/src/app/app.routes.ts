import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AppointmentComponent } from './appointment/appointment.component';
import { AuthGuard } from './auth.guard';
import { TodayAppointmentsComponent } from './components/today-appointments/today-appointments.component';

export const routes: Routes = [
    // { path: '', component: LoginComponent, pathMatch: 'full' },
    // { path: '**', component: LoginComponent },
    { path: '', component: LoginComponent },
    { path: 'dashboard', component: DashboardComponent },
    {
        path: 'appointment', component: AppointmentComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'today-appointment', component: TodayAppointmentsComponent,
        canActivate: [AuthGuard]
    },
];
