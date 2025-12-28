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
                loadChildren: () => import('./pages/companies/companies.routes').then(r => r.companiesRoutes)
            },
            {
                path: 'contacts',
                loadChildren: () => import('./pages/contacts/contacts.routes').then(r => r.contactsRoutes)
            },
            {
                path: 'activities',
                loadChildren: () => import('./pages/activities/activities.routes').then(r => r.activitiesRoutes)
            },
            {
                path: 'leads',
                loadChildren: () => import('./pages/leads/leads.routes').then(r => r.leadsRoutes)
            }
        ]
    }
];
