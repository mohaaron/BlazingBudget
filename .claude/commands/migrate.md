Run pending Entity Framework Core migrations.

## Instructions

1. Check for pending migrations: `dotnet ef migrations list --project src/Infrastructure/BlazingBudget.Infrastructure --startup-project src/Web/WebApi/BlazingBudget.WebApi`
2. If there are pending migrations, apply them: `dotnet ef database update --project src/Infrastructure/BlazingBudget.Infrastructure --startup-project src/Web/WebApi/BlazingBudget.WebApi`
3. Report the migrations that were applied
4. Report any errors encountered

## Notes

- The DbContext is `BudgetContext` in `BlazingBudget.Infrastructure.Persistence.EntityFramework`
- Migrations are stored in the Infrastructure project
