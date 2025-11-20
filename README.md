# Customer Relationship Management system

This repository contains both the backend API and the Angular frontend for a Customer Relationship Management (CRM) system.

The **Backend** is built with **ASP.NET Core 8**, **Entity Framework Core**, and **Identity with JWT authentication**. The solution follows clean architecture principles, ensuring separation of concerns and scalability.

The **Frontend** is an Angular application that consumes the backend API and implements the client-side user interface.


## Features

- User authentication and authorization
  - ASP.NET Core Identity
  - JWT-based authentication
  - Angular frontend includes Login page, JWT interceptor, and route guard for protected routes
- Role management
  - Admin, Manager, User roles (seeded on startup)
- Entity Framework Core
  - Generic repository pattern
  - Services for business logic
- DTOs and Mapping
- Swagger/OpenAPI
  - API documentation and testing is configured.

## Solution Structure

Backend/
- **CRM.Core** - Domain models & interfaces
- **CRM.Infrastructure** - EF Core, repositories, persistence
- **CRM.Application** - Services, DTOs, business logic
- **CRM.API** - API controllers, startup, auth

Frontend/
- **crm-frontend** - Angular application


## Setup and Run

### 1. Backend (CRM.API)

1.  **Clone the repository**
    - `git clone https://github.com/nowakczarek/CRM`
    - `cd CRM/Backend`
2.  **Configure the database**
    - Update the connection string in `CRM.API/appsettings.json`
    - **Apply migrations and seed initial users**: Run the application, as migrations are applied and initial users/roles are seeded on startup.
    - **Default seeded users**:
        - `admin@crm.pl` / `Admin123!` (Role: Admin)
        - `manager@crm.pl` / `Manager123!` (Role: Manager)
        - `user@crm.pl` / `User123!` (Role: User)
3.  **Run the API**
    - `dotnet run --project CRM.API`
    - The API runs on `https://localhost:7058` by default.

### 2. Frontend (crm-frontend)

1.  **Navigate to the frontend directory**
    - `cd ../Frontend/crm-frontend`
2.  **Install dependencies**
    - `npm install`
3.  **Run the application**
    - `npm start` or `ng serve`
    - The application runs on `http://localhost:4200` and is configured to communicate with the backend API.

## Technologies & Key Dependencies

### Backend (ASP.NET Core)
| Technology | Purpose | Key Dependency 
| :--- | :--- | :--- |
| **.NET Framework** | Core Framework | `Microsoft.NET.Sdk.Web` |
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

## Tech Stack
- **Backend**: ASP.NET Core 8, Entity Framework Core, SQL Server, ASP.NET Core Identity, JWT Authentication, Swagger/OpenAPI.
- **Frontend**: Angular, TypeScript, rxjs.


## Current Status & Next Steps

The core infrastructure is complete. Some API endpoints are to be added. The frontend development has a solid foundation.

### Completed (UI & Logic)
- **User Authentication**: Login, Logout, Session management via JWT.
- **Companies Module**: Full CRUD functionality is implemented on the Angular frontend.

### Next Steps
- Implement the User Interface (List, Create, Edit, Details) for the remaining core modules:
    - **Contacts**
    - **Leads**
    - **Activities**
- Enhance the UI/UX across the application (e.g., dashboard, better forms).