using BlazingBudget.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Account
{
    /// <summary>
    /// BudgetId 
    /// </summary>
    /// <remarks>https://www.youtube.com/watch?v=dJxVj6390hk</remarks>
    /// <param name="Value"></param>
    public struct AccountId : IEquatable<AccountId> //: IEntityId<Guid>;
    {
        [JsonConstructor]
        private AccountId(Guid value)
        {
            Value = value;
        }

        public static AccountId Create()
        {
            return new AccountId(Guid.NewGuid());
        }

        public Guid Value { get; }

        public bool Equals(AccountId other)
        {
            return Value == other.Value;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return obj is AccountId other && Equals(other);
        }

        public static bool operator ==(AccountId left, AccountId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AccountId left, AccountId right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
