using Abp.Domain.Entities;
using Ardalis.GuardClauses;
using BlazingBudget.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Account
{
    public sealed class Account : AggregateRoot<AccountId>
    {
        public PersonName Name { get; private set; }

        public Email Email { get; private set; }

        public Password Password { get; private set; }

        private Account() { }

        [JsonConstructor]
        private Account(AccountId id, PersonName name, Email email, Password password)
        {
            Id = id;
            Name = name;

            // new AccountService().CanCreateAccount(this);
            Email = email; // TODO: How does this rule get enforced?

            Password = password;

            //DomainEvents.Add(new AccountCreatedEvent(Id)); // Not yet implemented
        }

        public static Account Create(PersonName name, Email email, Password password)
        {
            return new Account(AccountId.Create(), name, email, password);
        }
    }
}
