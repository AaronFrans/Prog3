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
        public void PrintStock()
        {
            Console.WriteLine("-----------");
            foreach (KeyValuePair<Bestelling.ProductType, int> Item in Stock)
            {
                Console.WriteLine($"[stock:{Item.Key.ToString()}, {Item.Value}]");
            }
            Console.WriteLine("-----------");
        }
        public void HervulStock()
        {
            Dictionary<Bestelling.ProductType, int> TeHervullen = new Dictionary<Bestelling.ProductType, int>();
            for (int i = 0; i < Stock.Count; i++)
            {
               
                if (Stock.ElementAt(i).Value != max)
                {
                    Bestelling.ProductType productType = Stock.ElementAt(i).Key;
                    TeHervullen.Add(productType, max - Stock[productType]);
                    Stock[productType] = max;
                    
                }
                
            }

            OnHervul(TeHervullen);

        }


        public delegate void RefillStockEventHandler(object source, StockBeheerderEventArgs meta);
        public event RefillStockEventHandler Hervul;





        public void OnVerkoop(object source, WinkelEventArgs e)
        {
            Stock[e.Bestelling.Product] = Stock[e.Bestelling.Product] - e.Bestelling.Aantal;

            if (Stock[e.Bestelling.Product] < min)
            {
                Console.WriteLine($"Replace Stock to {max}  items");
                HervulStock();

            }
            Console.WriteLine("Verkocht");
        }

       protected virtual void OnHervul(Dictionary<Bestelling.ProductType, int> producten)
       {
            if (Hervul != null)
            {
                Hervul(this, new StockBeheerderEventArgs() { Products = producten});
            }
        }


    }
    public class StockBeheerderEventArgs : EventArgs
    {
        public Dictionary<Bestelling.ProductType, int> Products { get; set; } = new Dictionary<Bestelling.ProductType, int>();
    }
}


