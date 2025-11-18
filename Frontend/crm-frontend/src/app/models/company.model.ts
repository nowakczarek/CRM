export interface Company{
    id: string,
    name: string,
    industry?: string | null,
    nip: string,
    website?: string | null,
    phoneNumber?: string | null,
    address?: string | null,
    createdAt: string
}

export interface FormCompany{
    name: string,
    industry?: string | null,
    nip: string,
    website?: string | null,
    phoneNumber? : string | null,
    address?: string | null
}