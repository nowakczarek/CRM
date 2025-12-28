import { Routes } from "@angular/router";
import { List } from "./list/list";
import { authGuard } from "../../auth/guards/auth-guard";
import { Form } from "./form/form";

export const leadsRoutes : Routes = [
    {path: '', component: List, canActivate: [authGuard]},
    {path: 'new', component: Form, canActivate: [authGuard]}
]