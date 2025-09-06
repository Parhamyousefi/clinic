import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AppointmentComponent } from './appointment/appointment.component';

export const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'appointment', component: AppointmentComponent },
];
