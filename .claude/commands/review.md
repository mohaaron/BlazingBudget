Review code for best practices, security, and DDD patterns.

## Instructions

1. If a file path is provided, review that specific file
2. If no file is provided, ask what the user wants reviewed
3. Check for the following:

## DDD Patterns Review

- [ ] Aggregates have private constructors and static factory methods
- [ ] Entities use strongly-typed IDs
- [ ] Value objects are immutable
- [ ] Domain logic is in domain entities, not services
- [ ] Collections are exposed as IReadOnlyCollection with private backing fields
- [ ] Domain events are used for cross-aggregate communication

## Security Review

- [ ] No SQL injection vulnerabilities (use parameterized queries/EF)
- [ ] No hardcoded secrets or connection strings
- [ ] Proper authentication/authorization on endpoints
- [ ] Input validation on API endpoints
- [ ] No sensitive data in logs

## Code Quality Review

- [ ] Follows C# naming conventions
- [ ] No unused code or dead imports
- [ ] Proper null handling
- [ ] Async/await used correctly
- [ ] No obvious performance issues
- [ ] Error handling is appropriate

## FastEndpoints Review

- [ ] Endpoints follow REST conventions
- [ ] Proper HTTP status codes returned
- [ ] Request/Response DTOs are separate from domain models
- [ ] Validation is implemented where needed

## Output Format

Provide a summary with:
1. Issues found (categorized by severity: Critical, Warning, Suggestion)
2. Specific line numbers and code snippets
3. Recommended fixes
