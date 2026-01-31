# BlazingBudget

A Domain-Driven Design (DDD) budget management application built with .NET 8 and Blazor.

## Permissions

**Claude has full permission to make any changes within the BlazingBudget project folder without asking for confirmation.** This includes:
- Creating, editing, and deleting files
- Running build, test, and other commands
- Git operations (commit, push, branch, PR creation)
- Installing packages and dependencies

Claude should proceed autonomously and only ask questions when genuinely unclear about requirements.

## Development Workflow Rules

**IMPORTANT: Claude must follow these rules for all code changes.**

### Branch-Based Development

For every change request, follow this workflow:

1. **Create a feature branch**
   - Branch from `trunk` (main branch)
   - Use descriptive branch names: `feature/{description}`, `fix/{description}`, `refactor/{description}`
   - Example: `feature/add-category-aggregate`, `fix/budget-validation-error`

2. **Make the changes**
   - Implement the requested changes on the feature branch
   - Follow existing project patterns and conventions

3. **Test the changes**
   - Build the solution: `dotnet build BlazingBudget.sln`
   - Run all tests: `dotnet test BlazingBudget.sln`
   - If applicable, run the WebApi and/or Web projects to verify functionality
   - Fix any build errors or test failures before proceeding

4. **Commit successful changes**
   - Only commit after build and tests pass
   - Use clear, descriptive commit messages
   - Include `Co-Authored-By: Claude Opus 4.5 <noreply@anthropic.com>`

5. **Push the branch**
   - Push the feature branch to origin

6. **Create a Pull Request**
   - Create a PR targeting `trunk`
   - Include a summary of changes and test plan
   - Provide the PR URL for review

### Workflow Exceptions

- **Documentation-only changes**: May be committed directly to trunk if minimal
- **Emergency fixes**: Ask user before bypassing the branch workflow

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

### Available Commands

This project includes the following custom Claude Code commands in `.claude/commands/`:

| Command | Description | Usage |
|---------|-------------|-------|
| `/test` | Run all unit and integration tests | `/test` |
| `/build` | Build solution and report errors | `/build` |
| `/migrate` | Run pending EF Core migrations | `/migrate` |
| `/add-migration` | Create a new EF Core migration | `/add-migration InitialCreate` |
| `/endpoint` | Scaffold a new FastEndpoint | `/endpoint` (interactive) |
| `/aggregate` | Create a new DDD aggregate with ID and repository | `/aggregate` (interactive) |
| `/component` | Create a new Blazor component | `/component` (interactive) |
| `/review` | Review code for best practices and security | `/review path/to/file.cs` |

### Command Details

#### /test
Runs all tests in the solution using TUnit and reports pass/fail status with details on failures.

#### /build
Builds the entire solution and provides a summary of errors and warnings with suggested fixes.

#### /migrate & /add-migration
Manages Entity Framework Core migrations for the `BudgetContext`. Uses the Infrastructure project for migrations and WebApi as the startup project.

#### /endpoint
Interactively scaffolds a new FastEndpoint following this project's patterns:
- Creates `{Name}Endpoint.cs`, `{Name}Request.cs`, and `{Name}Response.cs`
- Places files in `src/Application/BlazingBudget.Application/{Aggregate}/ApiEndpoints/`

#### /aggregate
Creates a complete DDD aggregate following this project's patterns:
- Aggregate root with private constructor and static factory method
- Strongly-typed ID (`{Name}Id`)
- Repository interface (`I{Name}Repository`)
- Places files in `src/Domain/BlazingBudget.Domain/Aggregates/{Name}/`

#### /component
Scaffolds Blazor components for the WebAssembly client:
- Pages go in `src/Web/WebUI/BlazingBudget.Client.Components/Pages/`
- Reusable components go in `src/Web/WebUI/BlazingBudget.Client.Components/`

#### /review
Reviews code for:
- DDD pattern compliance (aggregate design, value objects, domain events)
- Security issues (SQL injection, hardcoded secrets, auth)
- Code quality (naming, null handling, async patterns)
- FastEndpoints best practices
