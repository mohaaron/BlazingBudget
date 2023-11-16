using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot<T>
    {
        T Get(Guid id);

        void Upsert(T aggregate);

        void Delete(Guid id);
    }
}
