import { Routes } from "@angular/router";
import { authGuard } from "../../auth/guards/auth-guard";
import { List } from "./list/list";
import { Details } from "./details/details";
import { Form } from "./form/form";

export const contactsRoutes : Routes = [
    {path: '', component: List, canActivate: [authGuard]},
    {path: 'new', component: Form, canActivate: [authGuard]},
    {path: ':id', component: Details, canActivate: [authGuard]},
    {path: ':id/edit', component: Form, canActivate: [authGuard]}
]