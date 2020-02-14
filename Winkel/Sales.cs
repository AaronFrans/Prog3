using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Winkel
{
    class Sales
    {
        public Dictionary<string, List<Bestelling>> Transactions { get; private set; } = new Dictionary<string, List<Bestelling>>();
        public void Rapport()
        {   
            #region Test
            //string adres = "5451651";
            //string adres2 = "afbjsagbfuh";

            //List<Bestelling> bestellings = new List<Bestelling>();
            //List<Bestelling> bestellings2 = new List<Bestelling>();
            //bestellings.Add(new Bestelling(Bestelling.ProductType.Dubbel, 5.22, 6, adres));
            //bestellings.Add(new Bestelling(Bestelling.ProductType.Kriek, 4.2, 4, adres));
            //bestellings.Add(new Bestelling(Bestelling.ProductType.Trippel, 2.99, 2, adres));
            //bestellings2.Add(new Bestelling(Bestelling.ProductType.Dubbel, 5.22, 6, adres2));
            //bestellings2.Add(new Bestelling(Bestelling.ProductType.Kriek, 4.2, 4, adres2));
            //bestellings2.Add(new Bestelling(Bestelling.ProductType.Trippel, 2.99, 2, adres2));
            //Transactions.Add(adres, bestellings);
            //Transactions.Add(adres2, bestellings2);
            #endregion



            Console.WriteLine("-----------");
            Console.WriteLine("Sales - raport");
            foreach(KeyValuePair<string, List<Bestelling>> Transaction in Transactions)
            {
                Console.WriteLine(Transaction.Key);
                for(int i = 0; i< Transaction.Value.Count; i++)
                {
                    Console.WriteLine($"{Transaction.Value[i].Product}, {Transaction.Value[i].Aantal}".PadLeft($"{Transaction.Value[i].Product}, {Transaction.Value[i].Aantal}".Length + 3)) ; 
                }
            }


            Console.WriteLine("-----------");
        }

        public void OnVerkoop(object source, WinkelEventArgs e)
        {
            bool isFound = false;
            for(int i = 0; i<Transactions.Count; i++)
            {
                if (e.Bestelling.Adres == Transactions.ElementAt(i).Key)
                {
                    Transactions.ElementAt(i).Value.Add(e.Bestelling);
                    isFound = true;
                    i = Transactions.Count + 1;
                }
            }
            if(isFound == false)
            {
                List<Bestelling> bestellingen = new List<Bestelling>() { e.Bestelling };
                Transactions.Add(e.Bestelling.Adres, bestellingen);           
            }

            
            Console.WriteLine("Raport gemaakt");
        }
    }
}
