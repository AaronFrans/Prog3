using System;
using System.Collections.Generic;
using System.Text;

namespace Winkel
{
    public class Bestelling
    {
        public enum ProductType
        {
            Trippel,
            Dubbel,
            Kriek,
            Pils,
        }

        public Bestelling(ProductType product, double prijs, int aantal, string adres)
        {
            this.Product = product;
            this.Prijs = prijs;
            this.Aantal = aantal;
            this.Adres = adres;

        }
        public ProductType Product { get; private set; }
        public double Prijs { get; private set; }
        public int Aantal { get; private set; }
        public string Adres { get; private set; }
    }
}
