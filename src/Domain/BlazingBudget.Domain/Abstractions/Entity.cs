using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Shared
{
    public abstract class Entity<TEntityId> : Abp.Domain.Entities.Entity<TEntityId> where TEntityId : class
    {
        public DateTime CreatedOn { get; protected set; }
        public DateTime UpdatedOn { get; protected set; }
    }
}
