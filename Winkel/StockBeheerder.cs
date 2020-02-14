using System;
using System.Collections.Generic;
using System.Text;

namespace Winkel
{
    class StockBeheerder
    {
        public StockBeheerder()
        {
            Stock.Add(Bestelling.ProductType.Dubbel, 100);
            Stock.Add(Bestelling.ProductType.Trippel, 100);
            Stock.Add(Bestelling.ProductType.Kriek, 100);
            Stock.Add(Bestelling.ProductType.Pils, 100);
        }
        public Dictionary<Bestelling.ProductType, int> Stock { get; private set; } = new Dictionary<Bestelling.ProductType, int>();
    }
}
