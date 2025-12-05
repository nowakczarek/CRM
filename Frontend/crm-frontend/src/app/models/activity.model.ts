import { ActivityType } from "./enums/activity-type"

export interface Activity{
    id: string,
    companyId : string,
    contactId : string,
    type: ActivityType,
    subject: string,
    description?: string | null,
    createdAt: string 
}

export interface FullActivity{
    id: string,
    companyId : string,
    contactId : string,
    type: ActivityType,
    companyName: string,
    contactFirstName: string,
    contactLastName: string,
    subject: string,
    description?: string | null,
    createdAt: string 
}

export interface FormActivity{
    companyId: string,
    contactId: string,
    type: ActivityType
    subject: string,
    description?: string | null
}