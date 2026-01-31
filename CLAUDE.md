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

## Claude Code Configuration

The `.claude` folder contains Claude Code settings and custom commands for this project.

```
.claude/
├── settings.local.json    # Local permissions (gitignore recommended)
├── settings.json          # Shared project settings
└── commands/              # Custom slash commands
    └── my-command.md      # Each .md file becomes a /my-command skill
```

### File Descriptions

| File | Purpose |
|------|---------|
| `settings.local.json` | User-specific permissions granted during sessions. Consider adding to `.gitignore` for personal preferences. |
| `settings.json` | Shared project settings (API keys excluded). Commit this to share team configurations. |
| `commands/*.md` | Custom slash commands. The filename (without .md) becomes the command name. |

### Creating Custom Commands

Create a markdown file in `.claude/commands/`. Example: `.claude/commands/test.md` creates the `/test` command.

Command file format:
```markdown
Run all tests in the solution and report any failures.

Use: dotnet test BlazingBudget.sln
```

### Useful Commands for ASP.NET Projects

| Command | Description |
|---------|-------------|
| `/test` | Run all unit and integration tests |
| `/build` | Build solution and report errors |
| `/migrate` | Run pending EF Core migrations |
| `/add-migration` | Create a new EF Core migration |
| `/endpoint` | Scaffold a new FastEndpoint |
| `/aggregate` | Create a new DDD aggregate with ID, entity, and events |
| `/component` | Create a new Blazor component |
| `/review` | Review code for best practices and security |
