export interface Contact{
    id: string,
    companyId: string,
    firstName: string,
    lastName: string,
    email?: string | null,
    phoneNumber?: string | null,
    position?: string | null,
    createdAt: string
}

export interface ContactWithCompanyName{
    id: string,
    companyId: string,
    companyName: string | null,
    firstName: string,
    lastName: string,
    email?: string | null,
    phoneNumber?: string | null,
    position?: string | null,
    createdAt: string
}

export interface FormContact{
    companyId: string
    firstName: string,
    lastName: string,
    email?: string | null,
    phoneNumber?: string | null,
    position?: string | null
}