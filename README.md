# BlazingBudget

A personal budget management application built with .NET 9, Blazor, and Domain-Driven Design (DDD) principles.

## Overview

BlazingBudget is a learning project exploring Domain-Driven Design patterns in a real-world context. The application helps users track their budgets, income, and expenses with a clean separation of concerns following DDD tactical patterns including aggregates, entities, value objects, and domain events.

## Architecture

The solution follows Clean Architecture with DDD tactical patterns:

```
BlazingBudget/
├── src/
│   ├── Domain/                    # Core business logic and domain models
│   │   └── BlazingBudget.Domain   # Aggregates, entities, value objects, domain events
│   │
│   ├── Application/               # Application services and use cases
│   │   ├── BlazingBudget.Application           # Handlers, services, API endpoints
│   │   └── BlazingBudget.Application.ViewModels # DTOs and view models
│   │
│   ├── Infrastructure/            # External concerns and persistence
│   │   └── BlazingBudget.Infrastructure        # EF Core, repositories, configurations
│   │
│   ├── Web/
│   │   ├── WebApi/                # FastEndpoints REST API
│   │   │   └── BlazingBudget.WebApi
│   │   └── WebUI/                 # Blazor WebAssembly client
│   │       ├── BlazingBudget                   # Server host
│   │       ├── BlazingBudget.Client            # WASM client
│   │       └── BlazingBudget.Client.Components # Shared Razor components
│   │
│   └── Aspire/                    # .NET Aspire orchestration
│       ├── BlazingBudget.AppHost              # Distributed app host
│       └── BlazingBudget.ServiceDefaults      # Shared service configuration
│
└── tests/                         # Unit and integration tests
    ├── BlazingBudget.Domain.Tests
    └── BlazingBudget.Application.Tests
```

### Layer Responsibilities

| Layer | Responsibility |
|-------|----------------|
| **Domain** | Business rules, aggregates, entities, value objects, domain events. No dependencies on other layers. |
| **Application** | Use cases, command/query handlers, API endpoints, application services. Depends only on Domain. |
| **Infrastructure** | Database access (EF Core), external services, repository implementations. Implements interfaces from Domain/Application. |
| **Web** | User interface (Blazor) and HTTP API (FastEndpoints). Entry point for the application. |
| **Aspire** | Orchestration, observability, and service discovery for distributed deployment. |

## Technologies

| Category | Technology |
|----------|------------|
| **Framework** | .NET 9 |
| **Web UI** | Blazor WebAssembly (hosted) |
| **API** | FastEndpoints |
| **ORM** | Entity Framework Core |
| **Database** | SQLite (development) |
| **Orchestration** | .NET Aspire 9.0 |
| **Observability** | OpenTelemetry |
| **Testing** | TUnit |
| **Patterns** | CSharpFunctionalExtensions (Result, Maybe) |
| **Mapping** | Mapster |

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- A code editor (Visual Studio 2022, VS Code, or Rider)

### Running the Application

**With .NET Aspire (Recommended):**

Run the application with the Aspire dashboard for observability:

```bash
dotnet run --project src/Aspire/BlazingBudget.AppHost --launch-profile https
```

The Aspire dashboard will open automatically at `https://localhost:17139`, providing:
- Real-time logs from all services
- Distributed tracing
- Metrics and health status

**Without Aspire:**

Run the WebAPI and Blazor app separately:

```bash
# Terminal 1 - Run the API
dotnet run --project src/Web/WebApi/BlazingBudget.WebApi

# Terminal 2 - Run the Blazor app
dotnet run --project src/Web/WebUI/BlazingBudget
```

### Building

```bash
dotnet build BlazingBudget.sln
```

### Running Tests

```bash
dotnet test BlazingBudget.sln
```

## Domain Model

The core domain includes the following aggregates:

- **Account** - User accounts that own budgets
- **Budget** - Monthly budget with income and expenses
- **Expense** - Planned expenses within a budget
- **Income** - Expected income sources
- **Payment** - Actual payments made against expenses

All aggregates use strongly-typed IDs (e.g., `BudgetId`, `AccountId`) for type safety and explicit domain modeling.

## Contributing

This is a learning project exploring DDD patterns. Feel free to open issues or pull requests if you have suggestions for improvements or find any issues with the DDD implementation.

---

*This README was written by [Claude Code](https://claude.ai/claude-code), Anthropic's AI coding assistant.*
