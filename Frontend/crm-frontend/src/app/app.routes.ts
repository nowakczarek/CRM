import { Routes } from '@angular/router';
import { Login } from './auth/login/login';
import { Dashboard } from './dashboard/dashboard';
import { authGuard } from './auth/guards/auth-guard';
import { Layout } from './layout/layout';

export const routes: Routes = [
    {
        path: 'login', component: Login
    },
    {
        path: '',
        component: Layout,
        canActivate: [authGuard],
        children: [
            {path: 'dashboard', component: Dashboard, canActivate:[authGuard]},
            {
                path: 'companies',
                loadChildren: () => import('./pages/companies/companies.routes').then(m => m.companiesRoutes)
            }
        ]
    }
];
