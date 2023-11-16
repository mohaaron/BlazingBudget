using BlazingBudget.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Infrastructure.Services
{
    /// <summary>
    /// Converts monetary value between currancies using external rate service
    /// </summary>
    public class ExchangeRateService : IExchangeRateService
    {
        public ExchangeRateService() { }
    }
}
