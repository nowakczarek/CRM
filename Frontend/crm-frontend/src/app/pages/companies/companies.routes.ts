import { Routes } from '@angular/router';
import { List } from './list/list'
import { Form } from './form/form'
import { Details } from './details/details';
import { authGuard } from '../../auth/guards/auth-guard';


export const companiesRoutes: Routes = [
    {path: '', component: List, canActivate:[authGuard] },
    {path: 'new', component: Form, canActivate: [authGuard]},
    {path: ':id', component: Details, canActivate: [authGuard]},
    {path: ':id/edit', component: Form, canActivate: [authGuard]}
]