using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Accounts
{
    public record AccountCreatedEvent(AccountId accountId) : IEventData
    {
        public DateTime EventTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object EventSource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
