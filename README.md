# Financial Core Platform

Enterprise-grade financial platform built with .NET 9, Clean Architecture, SQL Server, Docker, and modern software engineering practices.

---

## Overview

Financial Core Platform is a backend system designed to support financial and credit-related operations such as:

* Customer management
* Account management
* Loan applications
* Loan approval workflows
* Loan disbursements
* Payment processing
* Financial movements
* Audit logging
* Authentication and authorization

The project follows Clean Architecture principles to ensure maintainability, scalability, testability, and long-term sustainability.

---

## Architecture

The solution is organized into multiple projects following a modular architecture.

```text
FinancialPlatform.sln

src/
├── Financial.Api
├── Financial.Application
├── Financial.Domain
├── Financial.Persistence
└── Financial.Infrastructure

tests/
├── Financial.UnitTests
└── Financial.IntegrationTests
```

### Financial.Api

Responsible for:

* REST API endpoints
* Controllers
* Authentication
* Authorization
* Middleware
* Swagger/OpenAPI
* HTTP concerns

### Financial.Application

Contains:

* Use Cases
* Commands
* Queries
* Application Services
* Validation
* Interfaces

### Financial.Domain

Contains:

* Entities
* Value Objects
* Domain Services
* Business Rules
* Enumerations

This project has no dependency on infrastructure or external frameworks.

### Financial.Persistence

Contains:

* Entity Framework Core
* SQL Server integration
* Repositories
* Migrations
* Database configurations

### Financial.Infrastructure

Contains:

* JWT services
* Email services
* AWS integrations
* External providers
* Logging
* Time providers
* Future integrations

---

## Technology Stack

* .NET 9
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Docker
* Docker Compose
* Swagger/OpenAPI
* FluentValidation
* xUnit
* Clean Architecture

---

## Project Goals

* Separation of concerns
* Testability
* Scalability
* Security
* Auditability
* Maintainability

---

## Local Development

### Prerequisites

* .NET SDK 9
* Docker Desktop
* SQL Server (or Docker Compose)

### Run locally

```bash
dotnet restore
dotnet build
dotnet run --project src/Financial.Api
```

---

## Running with Docker Compose

The project can be executed together with SQL Server using Docker Compose.

```bash
docker compose up -d
```

Services:

```text
financial-api
sqlserver
```

---

## Testing

Run all tests:

```bash
dotnet test
```

Project structure:

```text
tests/
├── Financial.UnitTests
└── Financial.IntegrationTests
```

---

## Future Improvements

* Event-driven architecture
* Outbox pattern
* Distributed caching
* Background workers
* CQRS
* OpenTelemetry
* Prometheus & Grafana
* Multi-tenancy support

---

## License

This project is intended for educational and professional use purposes.