Create a new DDD aggregate for the BlazingBudget domain.

## Instructions

1. Ask the user for:
   - Aggregate name (e.g., `Transaction`, `Category`)
   - Key properties
   - Any child entities

2. Create the following files in `src/Domain/BlazingBudget.Domain/Aggregates/{Name}/`:
   - `{Name}.cs` - The aggregate root entity
   - `{Name}Id.cs` - The strongly-typed ID

3. Create repository interface in `src/Domain/BlazingBudget.Domain/Abstractions/`:
   - `I{Name}Repository.cs`

4. Optionally create domain events in the aggregate folder

## Aggregate Pattern

Follow this project's pattern from `Budget.cs`:

```csharp
using BlazingBudget.Domain.Aggregates.Accounts;

namespace BlazingBudget.Domain.Aggregates.{Name};

public sealed class {Name} : Entity<{Name}Id>
{
    private {Name}() { } // EF Core constructor

    private {Name}({Name}Id id, /* other params */)
    {
        Id = id;
        // Set properties
    }

    public static {Name} Create(/* params */)
        => new({Name}Id.New(), /* params */);

    // Properties with private setters
    public string PropertyName { get; private set; }

    // Collections as readonly with backing field
    public IReadOnlyCollection<ChildEntity> Children => children;
    private HashSet<ChildEntity> children = new();

    // Domain methods
    public void DoSomething(/* params */)
    {
        // Business logic
    }
}
```

## Strongly-Typed ID Pattern

```csharp
namespace BlazingBudget.Domain.Aggregates.{Name};

public readonly record struct {Name}Id(Guid Value)
{
    public static {Name}Id New() => new(Guid.NewGuid());
    public static {Name}Id Create() => new(Guid.Empty);
    public static {Name}Id Create(Guid value) => new(value);
}
```

## Repository Interface Pattern

```csharp
namespace BlazingBudget.Domain.Abstractions;

public interface I{Name}Repository
{
    Task<{Name}?> GetByIdAsync({Name}Id id, CancellationToken ct = default);
    Task AddAsync({Name} entity, CancellationToken ct = default);
    Task UpdateAsync({Name} entity, CancellationToken ct = default);
}
```
