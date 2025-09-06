import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AppointmentComponent } from './appointment/appointment.component';
import { AuthGuard } from './auth.guard';

export const routes: Routes = [
    { path: '', component: LoginComponent, pathMatch: 'full' },
    { path: '**', component: LoginComponent },
    { path: 'login', component: LoginComponent },
    { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
    { path: 'appointment', component: AppointmentComponent, canActivate: [AuthGuard] },
];
