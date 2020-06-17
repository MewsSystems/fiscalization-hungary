using System.Collections.Generic;
using System.Linq;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Amount
    {
        public Amount(AmountType net, AmountType gross, AmountType tax)
        {
            Net = net;
            Gross = gross;
            Tax = tax;
        }

        public AmountType Net { get; }

        public AmountType Gross { get; }

        public AmountType Tax { get; }

        internal static Amount Sum(IEnumerable<Amount> amounts)
        {
            return new Amount(
                net: new AmountType(amounts.Sum(a => a.Net.Value)),
                gross: new AmountType(amounts.Sum(a => a.Gross.Value)),
                tax: new AmountType(amounts.Sum(a => a.Tax.Value))
            );
        }
    }
}
