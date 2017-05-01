using System.Collections.Generic;

namespace Skyscanner.Contracts.Settings.Currencies
{
    public class CurrenciesWrapper
    {
        public IEnumerable<Currency> Currencies { get; set; }
    }
}
