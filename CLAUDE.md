# BlazingBudget

A Domain-Driven Design (DDD) budget management application built with .NET 8 and Blazor.

## Project Structure

- `src/Domain/` - Domain layer with aggregates, entities, value objects, and domain events
- `src/Application/` - Application layer with handlers, services, and view models
- `src/Infrastructure/` - Infrastructure layer with Entity Framework, repositories, and persistence
- `src/Web/WebApi/` - FastEndpoints-based Web API
- `src/Web/WebUI/` - Blazor WebAssembly client
- `tests/` - Test projects

## Build & Run

```bash
# Build the solution
dotnet build BlazingBudget.sln

# Run the Web API (http://localhost:5260)
dotnet run --project src/Web/WebApi/BlazingBudget.WebApi

# Run the Blazor app (http://localhost:5239)
dotnet run --project src/Web/WebUI/BlazingBudget
```

## Key Technologies

- .NET 8
- Blazor WebAssembly
- Entity Framework Core
- FastEndpoints
- Mediator (for CQRS)
- CSharpFunctionalExtensions
- TUnit (for testing)
