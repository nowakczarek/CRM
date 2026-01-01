import { Company } from "./company.model";
import { Contact } from "./contact.model";
import { Lead } from "./lead.model";

export interface GlobalSearchDto{
    companies: Company[] | null
    contacts: Contact[] | null
    leads: Lead[] | null
}