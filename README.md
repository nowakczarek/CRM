# CRM Backend

This is the backend API for a Customer Relationship Management (CRM) system.  
It is built with **ASP.NET Core 8**, **Entity Framework Core**, and **Identity with JWT authentication**.  
The solution follows clean architecture principles, ensuring separation of concerns and scalability.

---

## Features

- User authentication and authorization  
  - ASP.NET Core Identity  
  - JWT-based authentication  
- Role management  
  - Admin, Manager, Client roles  
- Core CRM modules  
  - Companies  
  - Contacts  
  - Leads  
  - Activities  
- Entity Framework Core  
  - Generic repository pattern  
  - Services for business logic  
- DTOs and Mapping  
  - Separation between persistence models and exposed data  
- Swagger/OpenAPI  
  - API documentation and testing  

---

## Solution Structure

Backend/
- CRM.Core # Domain models & interfaces
- CRM.Infrastructure # EF Core, repositories, persistence
- CRM.Application # Services, DTOs, business logic
- CRM.API # API controllers, startup, auth

---

## Setup and Run

1. **Clone the repository**  
   git clone https://github.com/<your-username>/CRM
   cd CRM/Backend
   
2. **Configure the database**
   - Update the connection string in appsettings.json
   - Apply migrations: dotnet ef database update --project CRM.Infrastructure --startup-project CRM.API

3. **Run the API**
   - dotnet run --project CRM.API

---

## Tech Stack
- ASP.NET Core 7
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- JWT Authentication
- Swagger / OpenAPI

---

## Next Steps

- Start frontend with Angular (TypeScript).
- Connect frontend with backend via HTTP calls.
- Extend CRM features with dashboards, reporting, and user management.
