using Abp;
using Abp.Domain.Entities;
using BlazingBudget.Domain.Aggregates.Budget;
using BlazingBudget.Domain.ValueObjects;
using CSharpFunctionalExtensions;

namespace BlazingBudget.Domain.Aggregates.Debt
{
    public sealed class Debt : AggregateRoot<DebtId>
    {
        private Debt() { }

        [JsonConstructor]
        private Debt(DebtId id, string name, Money total)
        {
            Id = id;
            Name = name;
            Total = total;

            //DomainEvents.Add(new DebtCreatedEvent())
        }

        public static IResult<Debt> Create(string name, Money total)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Debt>("Name cannot be empty");
            }

            return Result.Success(new Debt(DebtId.New(), name, total));
        }

        public string Name { get; private set; }

        public Money Total { get; }

        public Amount AmountPaid => Amount.Create(payments.Sum(paid => paid.Amount.Value)).Value;

        public Amount AmountOwed => Amount.Create(Total.Value - AmountPaid.Value).Value;

        public IReadOnlyCollection<Payment> Payments => payments;

        private HashSet<Payment> payments { get; set; } = new HashSet<Payment>();

        public void MakePayment(Payment payment)
        {
            payments.Add(payment);
        }
    }
}
