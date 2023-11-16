using BlazingBudget.Domain.Interfaces;
using BlazingBudget.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Services
{
    internal class CurrencyExchange
    {
        private readonly IExchangeRateService _exchangeRateService;

        public CurrencyExchange(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService ?? throw new ArgumentNullException(nameof(exchangeRateService));
        }

        public Money ExchangeToCurrency(Money amount, Currency currency)
        {
            return new Money(amount.Value, currency);
        }
    }
}
