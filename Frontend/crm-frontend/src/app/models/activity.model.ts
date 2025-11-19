import { ActivityType } from "./enums/activity-type"

export interface Activity{
    id: string,
    companyId : string,
    contactId : string,
    subject: string,
    description?: string | null,
    createdAt: string 
}

export interface FormActivity{
    companyId: string,
    contactId: string,
    activityType: ActivityType
    subject: string,
    description: string | null
}