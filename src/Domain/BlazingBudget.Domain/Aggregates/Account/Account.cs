using Abp.Domain.Entities;
using Ardalis.GuardClauses;
using BlazingBudget.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Account
{
    public sealed class Account : AggregateRoot<AccountId>
    {
        private Account() { }

        private Account(AccountId accountId, PersonName name, Email email, Password password)
        {
            Id = accountId;
            Name = name;
            Email = email;
            Password = password;

            DomainEvents.Add(new AccountCreatedEvent(Id));
        }

        public static Account Create(PersonName name, Email email, Password password)
        {
            return new Account(new AccountId(Guid.NewGuid()), name, email, password);
        }

        public PersonName Name { get; private set; }

        public Email Email { get; private set; }

        public Password Password { get; private set; }
    }
}
