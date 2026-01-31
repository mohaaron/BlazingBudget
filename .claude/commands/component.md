Create a new Blazor component for the BlazingBudget client.

## Instructions

1. Ask the user for:
   - Component name (e.g., `BudgetCard`, `ExpenseList`)
   - Component type (page or reusable component)
   - Location (which folder in the component library)

2. For pages, create in `src/Web/WebUI/BlazingBudget.Client.Components/Pages/`
3. For reusable components, create in `src/Web/WebUI/BlazingBudget.Client.Components/`

## Page Component Pattern

```razor
@page "/route"

<PageTitle>Page Title</PageTitle>

<h1>Page Heading</h1>

@code {
    // Component logic
}
```

## Reusable Component Pattern

```razor
<div class="component-container">
    @* Component markup *@
</div>

@code {
    [Parameter]
    public string Title { get; set; } = string.Empty;

    [Parameter]
    public EventCallback<string> OnAction { get; set; }

    // Component logic
}
```

## Notes

- Components are in the `BlazingBudget.Client.Components` project
- Use Blazor WebAssembly patterns (client-side)
- Follow existing component naming conventions
