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

        private Debt(DebtId id, string name, Money amountOwed)
        {
            Id = id;
            Name = name;
            AmountOwed = amountOwed;

            //DomainEvents.Add(new DebtCreatedEvent())
        }

        public static IResult<Debt> Create(string name, Money amountOwed)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Debt>("Name cannot be empty");
            }

            return Result.Success(new Debt(DebtId.New(), name, amountOwed));
        }

        public string Name { get; private set; }

        public Money AmountOwed { get; }

        public Money AmountPaid => new Money(payments.Sum(pmd => pmd.Amount.Value));

        public Money AmountToPayOff => new Money(AmountOwed.Value - AmountPaid.Value);

        public IReadOnlyCollection<Payment> Payments => payments;

        private HashSet<Payment> payments { get; set; } = new HashSet<Payment>();

        public void MakePayment(Payment payment)
        {
            payments.Add(payment);
        }
    }
}
