using System;

namespace Winkel
{

    class Program
    {
        public static void Main( string[] args)
        {
            Winkel winkel = new Winkel();//publisher
            StockBeheerder stock = new StockBeheerder(); //subscriber 1
            Sales sales = new Sales(); // subscriber 2;
            winkel.Verkoop += stock.OnVerkoop;
            winkel.Verkoop += sales.OnVerkoop;
            winkel.VerkoopProduct(new Bestelling(Bestelling.ProductType.Dubbel, 12.05, 20, "hfjsngkjN"));
            winkel.VerkoopProduct(new Bestelling(Bestelling.ProductType.Dubbel, 12.05, 20, "sgbgsj"));
            winkel.VerkoopProduct(new Bestelling(Bestelling.ProductType.Dubbel, 12.05, 20, "hfjsngkjN"));
            winkel.VerkoopProduct(new Bestelling(Bestelling.ProductType.Dubbel, 12.05, 20, "sgbgsj"));

            sales.Rapport();

        }
    }

}
