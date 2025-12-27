# DotNet8-RestAPI-With-EFCore

## Overview

This project is a **robust, enterprise-level RESTful API** built using **.NET 8**, **ASP.NET Core**, and **Entity Framework Core (EF Core)**. It demonstrates modern, best-practice backend development, including layered architecture, JWT authentication, repository patterns, and dependency injection. The API provides a fully functional **Task Management system**, suitable as a starting point for real-world applications.

---

## Features

- **RESTful API Endpoints**
  - `GET /api/v1/tasks` – Retrieve all tasks
  - `GET /api/v1/tasks/{id}` – Retrieve a specific task
  - `POST /api/v1/tasks` – Create a new task
  - `PUT /api/v1/tasks/{id}` – Update an existing task
  - `DELETE /api/v1/tasks/{id}` – Delete a task
- **JWT Authentication & Authorization**
  - Secure API endpoints using `[Authorize]` attribute
  - Login endpoint returns a JWT token for authenticated requests
- **Layered Architecture**
  - **Presentation Layer**: Controllers handle HTTP requests and responses
  - **Business Logic Layer**: Services encapsulate rules and operations
  - **Data Access Layer**: Repositories handle EF Core queries
  - **Persistence Layer**: EF Core `DbContext` and SQLite/Database
- **Entity Framework Core**
  - Async queries and tracking
  - Repository pattern for data access
  - Migrations for database schema management
- **Dependency Injection**
  - Interfaces for services and repositories (`ITaskService`, `ITaskRepository`)
  - Scoped service lifetimes for per-request instances
- **DTOs for data transfer**
  - Create, Update, and Read DTOs separate from EF models
- **Swagger / OpenAPI**
  - Built-in API documentation for easy testing and exploration
- **Ready for Production**
  - Dockerized for containerized deployment
  - Compatible with **Azure App Service** or any container platform

---

## Tech Stack
- Backend: .NET 8, ASP.NET Core Web API
- Database: SQLite (via EF Core)
- Authentication: JWT Bearer Tokens
- Documentation: Swagger / OpenAPI
- Deployment: Docker, Azure App Service
- Testing: Async methods, unit-testable via interfaces

---

# Run locally
### Prerequisites
- .NET 8 SDK
- SQLite
- Docker
- Postman/Swagger (for API testing)

1. Clone repository
```
git clone https://github.com/drewvcle/DotNet8-RestAPI-With-EFCore.git
cd DotNet8-RestAPI-With-EFCore
```
2. Apply EF Core migrations
```
dotnet ef database update
```
3. Run the API
```
dotnet run
```
4. Open Swagger UI
```
http://localhost:5070/swagger
```
5. Authenticate via `/api/v1/auth/login` and use the JWT token to access `/api/v1/tasks`.

---
# Architecture Overview
Request Flow:

1. HTTP Request → Controller (TasksController)
2. Controller calls Service Layer (TaskService)
3. Service calls Repository (TaskRepository)
4. Repository uses EF Core DbContext to query/update database
5. Database returns data → Repository → Service → Controller → HTTP Response

---

# Example Request
### Create Task
```
POST /api/v1/tasks
Authorization: Bearer <JWT_TOKEN>
Content-Type: application/json

{
  "title": "Finish project",
  "description": "Complete the .NET API example",
  "isCompleted": false
}
```
### Response
```
{
  "id": 1,
  "title": "Finish project",
  "description": "Complete the .NET API example",
  "isCompleted": false
}
```
# Contributing
- Fork the repo (https://github.com/drewvcle/DotNet8-RestAPI-With-EFCore)
- Create a new branch
- Implement features or fixes
- Open a pull request


