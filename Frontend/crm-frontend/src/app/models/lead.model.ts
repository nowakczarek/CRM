import { LeadStage } from "./enums/lead-stage";

export interface FullLead{
    id: string,
    companyId: string,
    contactId: string,
    title: string,
    value: number,
    stage: LeadStage,
    companyName: string,
    contactFirstName: string,
    contactLastName: string,
    createdAt: string
}


export interface Lead{
    id: string,
    companyId: string,
    contactId: string,
    title: string,
    value: number,
    stage: LeadStage,
    createdAt: string
}

export interface FormLead{
    companyId: string,
    contactId: string,
    title: string,
    value: number,
    stage: LeadStage
}