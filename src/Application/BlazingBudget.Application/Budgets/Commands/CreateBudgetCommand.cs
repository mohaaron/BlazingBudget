using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Application.Budgets.Commands
{
    public class CreateBudgetCommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
