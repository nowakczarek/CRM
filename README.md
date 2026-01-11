# Customer Relationship Management system

This repository contains both the backend REST API and the Angular frontend for a Customer Relationship Management (CRM) system.

The **Backend** is built with **ASP.NET Core 8**, **Entity Framework Core**, and **Identity with JWT authentication**.

The **Frontend** is an Angular 20 application that consumes the backend API and implements the user interface.


## Features

- User authentication and authorization
  - ASP.NET Core Identity
  - JWT-based authentication
  - Angular frontend includes Login page, JWT interceptor, and route guard for protected routes
- Role management
  - Admin, Manager, User roles (seeded on startup)
- Entities Management
  - Full CRUD functionality for Companies, Contacts, Activities and Leads
- Lead Tracking
  - Managing sales leads through various stages(New, Negotiations, Lost, Won)
- Activity Interaction Tracking:
  - Logging specific interactions with user-friendly UI
- Global search
  - Integrated global search funtionality across entities
- Swagger/OpenAPI
  - API documentation and testing is configured.

## Solution Structure

Backend/
- **CRM.Core** - Domain models & interfaces
- **CRM.Infrastructure** - EF Core, repositories, persistence
- **CRM.Application** - Services, DTOs, Mappings
- **CRM.API** - API controllers, startup, auth

Frontend/crm-frontend/
- **src/app/auth**: Login components and authentication logic.
- **src/app/pages**: Specific modules for Activities, Companies, Contacts, and Leads.
- **src/app/services**: Angular services for API communication.


## Setup and Run

1. **Prerequisites**:
   - Install [Docker Desktop](https://www.docker.com/products/docker-desktop/).
   - Ensure docker is running.

2. **Run the system**:
   - `git clone https://github.com/nowakczarek/CRM`
   - `cd CRM`
   - `docker-compose up --build`

3. **Access the Applications**
    - Once the containers are healthy, you can access the following:
    - Frontend Dashboard: `http://localhost:4200`
    - API Documentation (Swagger): `http://localhost:7058/swagger`

**Default seeded users**:
-   `admin@crm.pl` / `Admin123!` (Role: Admin)
-   `manager@crm.pl` / `Manager123!` (Role: Manager)
-   `user@crm.pl` / `User123!` (Role: User)

**Default seeded data**
- To provide a benchmark experience, the database is populated with sample data using **Bogus** library. 


## Technologies & Key Dependencies

### Backend (ASP.NET Core)
| Technology | Purpose | Key Dependency 
| :--- | :--- | :--- |
| **.NET 8** | Core Framework | `Microsoft.NET.Sdk.Web` |
| **Database** | ORM, SQL Server | `Microsoft.EntityFrameworkCore.SqlServer` |
| **Identity** | User/Role management | `Microsoft.AspNetCore.Identity.EntityFrameworkCore` |
| **JWT Auth** | Token generation & validation | `Microsoft.AspNetCore.Authentication.JwtBearer` |
| **API Docs** | Swagger/OpenAPI | `Swashbuckle.AspNetCore` |

### Frontend (Angular)
| Technology | Purpose | Key Dependency |
| :--- | :--- | :--- |
| **Framework** | Client-side application | `@angular/core` |
| **Routing** | Navigation and routing | `@angular/router` |
| **Forms** | Reactive Forms implementation | `@angular/forms` |
| **HTTP Client** | Backend communication | `@angular/common` |
| **Reactive Programming** | Asynchronous operations | `rxjs` |
| **Angular Material** | UI Improvement | `@angular/material/` |

## Tech Stack
- **Backend**: ASP.NET Core 8, Entity Framework Core, SQL Server, ASP.NET Core Identity, JWT Authentication, Swagger/OpenAPI.
- **Frontend**: Angular 20, TypeScript, rxjs, Angular Material, CSS, HTML.


## Next steps
- Improving UI/UX
- Adding pagination
- Implementing a central dashboard
- Adding search for specific modules