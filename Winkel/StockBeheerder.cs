using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Winkel
{
    class StockBeheerder
    {
        int min = 25;
        int max = 300;
        public StockBeheerder()
        {
            Stock.Add(Bestelling.ProductType.Dubbel, 100);
            Stock.Add(Bestelling.ProductType.Trippel, 100);
            Stock.Add(Bestelling.ProductType.Kriek, 100);
            Stock.Add(Bestelling.ProductType.Pils, 100);
        }
        public Dictionary<Bestelling.ProductType, int> Stock { get; private set; } = new Dictionary<Bestelling.ProductType, int>();

        public void OnVerkoop(object source, WinkelEventArgs e)
        {
            Stock[e.Bestelling.Product] = Stock[e.Bestelling.Product] - e.Bestelling.Aantal;

            if(Stock[e.Bestelling.Product] < min)
            {
                Console.WriteLine($"Replace Stock to {max}");
            }
            Console.WriteLine("Verkocht");
        }
    }
}
