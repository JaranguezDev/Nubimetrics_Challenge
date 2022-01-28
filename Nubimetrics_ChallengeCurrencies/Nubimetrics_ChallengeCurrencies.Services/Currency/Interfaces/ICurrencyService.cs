using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nubimetrics_ChallengeCurrencies.Services.Currency.Interfaces
{
    public interface ICurrencyService
    {
        Task ProcessCurrencyConversion();
    }
}
