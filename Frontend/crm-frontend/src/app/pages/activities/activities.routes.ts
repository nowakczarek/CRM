import { Routes } from "@angular/router";
import { List } from "./list/list";
import { authGuard } from "../../auth/guards/auth-guard";
import { Form } from "./form/form";
import { Details } from "./details/details";


export const activitiesRoutes: Routes = [
    {path: '', component: List, canActivate: [authGuard]},
    {path: 'new', component: Form, canActivate: [authGuard]},
    {path: ':activityId', component: Details, canActivate: [authGuard]},
    {path: ':activityId/edit', component: Form, canActivate: [authGuard]}
]