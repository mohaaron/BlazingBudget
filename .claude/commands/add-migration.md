Create a new Entity Framework Core migration.

## Instructions

1. Ask the user for a migration name if not provided as an argument
2. Create the migration: `dotnet ef migrations add {MigrationName} --project src/Infrastructure/BlazingBudget.Infrastructure --startup-project src/Web/WebApi/BlazingBudget.WebApi`
3. Show the generated migration files
4. Summarize what changes the migration will make

## Notes

- The DbContext is `BudgetContext` in `BlazingBudget.Infrastructure.Persistence.EntityFramework`
- Migration naming convention: Use PascalCase descriptive names (e.g., `AddAccountTable`, `UpdateBudgetSchema`)
- Migrations are stored in the Infrastructure project
