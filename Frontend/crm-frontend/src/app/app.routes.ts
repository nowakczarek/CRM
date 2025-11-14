import { Routes } from '@angular/router';
import { Login } from './auth/login/login';
import { Dashboard } from './dashboard/dashboard';
import { authGuard } from './auth/guards/auth-guard';

export const routes: Routes = [
    {
        path: 'login', component: Login
    },
    {
        path: '', redirectTo: 'login', pathMatch: 'full'
    },
    {
        path: 'dashboard', component: Dashboard, canActivate: [authGuard]
    }
];
