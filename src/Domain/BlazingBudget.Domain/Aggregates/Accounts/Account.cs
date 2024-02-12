using Abp.Domain.Entities;
using Ardalis.GuardClauses;
using BlazingBudget.Domain.ValueObjects;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Accounts
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
            Email = email;
            Password = password;

            //DomainEvents.Add(new AccountCreatedEvent(Id)); // Not yet implemented
        }

        public static Result<Account> Create(PersonName name, Email email, Password password)
        {
            return Result.Success(new Account(AccountId.Create(), name, email, password));
        }
    }
}
