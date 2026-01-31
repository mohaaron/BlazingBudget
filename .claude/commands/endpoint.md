Scaffold a new FastEndpoint for the BlazingBudget API.

## Instructions

1. Ask the user for:
   - Endpoint name (e.g., `GetAccounts`, `CreateBudget`)
   - HTTP method (GET, POST, PUT, DELETE)
   - Route path (e.g., `accounts`, `budgets/{id}`)
   - Which aggregate/domain area it belongs to

2. Create the following files in `src/Application/BlazingBudget.Application/{Aggregate}/ApiEndpoints/`:
   - `{Name}Endpoint.cs` - The endpoint handler
   - `{Name}Request.cs` - The request DTO
   - `{Name}Response.cs` - The response DTO (if needed)

## Template Pattern

Follow this project's endpoint pattern:

```csharp
using BlazingBudget.Infrastructure.Persistence.EntityFramework;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BlazingBudget.Application.{Aggregate}.ApiEndpoints;

public class {Name}Endpoint : Endpoint<{Name}Request, {ResponseType}>
{
    private readonly BudgetContext context;

    public {Name}Endpoint(BudgetContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        {HttpMethod}("{route}");
        AllowAnonymous(); // Or use appropriate auth
    }

    public override async Task HandleAsync({Name}Request req, CancellationToken ct)
    {
        // Implementation
        await SendAsync(response, (int)HttpStatusCode.OK, ct);
    }
}
```

## Request Pattern

```csharp
namespace BlazingBudget.Application.{Aggregate}.ApiEndpoints;

public record {Name}Request(/* parameters */);
```
