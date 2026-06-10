# Financial Core Platform

Plataforma financiera empresarial desarrollada con .NET 8, Clean Architecture, SQL Server, Docker y buenas prácticas modernas de ingeniería de software.

---

## Descripción General

Financial Core Platform es un backend diseñado para soportar operaciones financieras y crediticias como:

* Gestión de clientes
* Gestión de cuentas
* Solicitudes de crédito
* Flujos de aprobación
* Desembolsos
* Procesamiento de pagos
* Movimientos financieros
* Auditoría
* Autenticación y autorización

El proyecto sigue los principios de Clean Architecture para facilitar el mantenimiento, escalabilidad y evolución del sistema.

---

## Arquitectura

La solución se encuentra organizada en múltiples proyectos.

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

Responsabilidades:

* Endpoints REST
* Controllers
* Middleware
* Swagger
* Seguridad
* Autenticación
* Autorización

### Financial.Application

Contiene:

* Casos de uso
* Commands
* Queries
* Servicios de aplicación
* Validaciones
* Interfaces

### Financial.Domain

Contiene:

* Entidades
* Value Objects
* Servicios de dominio
* Reglas de negocio
* Enumeraciones

No depende de SQL Server, ASP.NET ni servicios externos.

### Financial.Persistence

Contiene:

* Entity Framework Core
* SQL Server
* Repositorios
* Migraciones
* Configuración de entidades

### Financial.Infrastructure

Contiene:

* JWT
* Email
* AWS
* Integraciones externas
* Logging
* Servicios auxiliares

---

## Stack Tecnológico

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Docker
* Docker Compose
* Swagger/OpenAPI
* FluentValidation
* xUnit

---

## Objetivos del Proyecto

* Separación de responsabilidades
* Escalabilidad
* Mantenibilidad
* Seguridad
* Auditabilidad
* Testabilidad

---

## Desarrollo Local

### Requisitos

* .NET SDK 8
* Docker Desktop
* SQL Server

### Ejecución local

```bash
dotnet restore
dotnet build
dotnet run --project src/Financial.Api
```

---

## Docker Compose

La aplicación puede ejecutarse junto con SQL Server utilizando Docker Compose.

```bash
docker compose up -d
```

Servicios:

```text
financial-api
sqlserver
```

---

## Testing

Ejecutar todos los tests:

```bash
dotnet test
```

Estructura:

```text
tests/
├── Financial.UnitTests
└── Financial.IntegrationTests
```

---

## Mejoras Futuras

* Arquitectura orientada a eventos
* Outbox Pattern
* CQRS
* OpenTelemetry
* Prometheus
* Grafana
* Cache distribuida
* Multi-tenancy

---

## Licencia

Proyecto desarrollado con fines educativos, de aprendizaje y para uso profesional.