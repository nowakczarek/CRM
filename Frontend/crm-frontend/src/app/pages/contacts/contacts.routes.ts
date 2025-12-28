import { Routes } from "@angular/router";
import { authGuard } from "../../auth/guards/auth-guard";
import { List } from "./list/list";
import { Details } from "./details/details";
import { Form } from "./form/form";

export const contactsRoutes : Routes = [
    {path: '', component: List, canActivate: [authGuard]},
    {path: 'new', component: Form, canActivate: [authGuard]},
    {path: ':contactId', component: Details, canActivate: [authGuard]},
    {path: ':contactId/edit', component: Form, canActivate: [authGuard]},
    {
        path: ':contactId/activities',
        loadChildren: () =>
            import('../activities/activities.routes').then(r => r.activitiesRoutes)
    },
    {
        path: ':contactId/leads',
        loadChildren: () =>
            import('../leads/leads.routes').then(r => r.leadsRoutes)
    }
]