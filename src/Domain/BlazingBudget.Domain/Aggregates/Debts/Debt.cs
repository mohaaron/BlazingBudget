﻿using Abp;
using Abp.Domain.Entities;
using BlazingBudget.Domain.Aggregates.Budgets;
using BlazingBudget.Domain.ValueObjects;
using CSharpFunctionalExtensions;

namespace BlazingBudget.Domain.Aggregates.Debts
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

        public static Result<Debt> Create(string name, Money total)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Debt>($"[{nameof(Debt)}] Name cannot be empty");
            }

            return Result.Success(new Debt(DebtId.New(), name, total));
        }

        public string Name { get; private set; }

        public Money Total { get; }

        /// <summary>
        /// Amount paid is the sum of all payments. Defaults to zero.
        /// </summary>
        public MoneyPaid AmountPaid => MoneyPaid.Create(payments.Sum(paid => paid.Amount.Value)).Value;

        /// <summary>
        /// Amount still owed on this debt is the total debt minus the amount paid.
        /// </summary>
        public MoneyOwed AmountOwed => MoneyOwed.Create(Total.Value - AmountPaid.Value).Value;

        /// <summary>
        /// TODO: Change to DebtPayment
        /// </summary>
        public IReadOnlyCollection<Payment> Payments => payments;

        private HashSet<Payment> payments { get; set; } = new HashSet<Payment>();

        public void MakePayment(Payment payment)
        {
            payments.Add(payment);
        }
    }
}
