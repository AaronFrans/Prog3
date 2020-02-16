using System;

namespace Winkel
{

    class Program
    {
        public static void Main( string[] args)
        {
            Winkel winkel = new Winkel();//publisher
            StockBeheerder stock = new StockBeheerder(); //subscriber1 van publisher
            Sales sales = new Sales(); // subscriber2 van publisher; //publisher2
            Groothandelaar groothandelaar = new Groothandelaar(); //subscriber 1 van publisher2

            winkel.Verkoop += stock.OnVerkoop;
            winkel.Verkoop += sales.OnVerkoop;

            stock.Hervul += groothandelaar.OnHervul;
            winkel.VerkoopProduct(new Bestelling(Bestelling.ProductType.Dubbel, 12.05, 20, "hfjsngkjN"));
            winkel.VerkoopProduct(new Bestelling(Bestelling.ProductType.Dubbel, 12.05, 20, "sgbgsj"));
            winkel.VerkoopProduct(new Bestelling(Bestelling.ProductType.Dubbel, 12.05, 20, "hfjsngkjN"));
            winkel.VerkoopProduct(new Bestelling(Bestelling.ProductType.Dubbel, 12.05, 20, "sgbgsj"));
            winkel.VerkoopProduct(new Bestelling(Bestelling.ProductType.Trippel, 12.05, 250, "hfjsngkjN"));
            winkel.VerkoopProduct(new Bestelling(Bestelling.ProductType.Dubbel, 12.05, 250, "hfjsngkjN"));
            winkel.VerkoopProduct(new Bestelling(Bestelling.ProductType.Kriek, 12.05, 250, "hfjsngkjN"));
            winkel.VerkoopProduct(new Bestelling(Bestelling.ProductType.Pils, 12.05, 276, "hfjsngkjN"));


            sales.Rapport();

            groothandelaar.PrintLastOrder();
            groothandelaar.PrintOrders();




        }
    }

}
