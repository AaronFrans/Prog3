using System;
using System.Collections.Generic;
using System.Text;

namespace Winkel
{
    class Groothandelaar
    {




        List<Dictionary<Bestelling.ProductType, int>> Orders = new List<Dictionary<Bestelling.ProductType, int>>();

        public void PrintOrders()
        {
            int counter = 1;
            foreach (Dictionary<Bestelling.ProductType, int> Order in Orders)
            {
                Console.WriteLine("-----------");
                Console.WriteLine($"Bestelling {counter}"); 
                foreach (KeyValuePair<Bestelling.ProductType, int> Item in Order)
                {
                    Console.WriteLine(Item.Value + ", " + Item.Key.ToString());
                }

                Console.WriteLine("-----------");
            }
        }

        public void PrintLastOrder()
        {
            int index = Orders.Count - 1;
            Console.WriteLine("-----------");
            Console.WriteLine($"Bestelling {index + 1}");
            foreach (KeyValuePair<Bestelling.ProductType, int> Item in Orders[index])
            {
                Console.WriteLine(Item.Value + ", " + Item.Key.ToString());
            }
            Console.WriteLine("-----------");
        }

        public void OnHervul(object source, StockBeheerderEventArgs e)
        {
            Orders.Add(e.Products);
        }

    }
    
}
