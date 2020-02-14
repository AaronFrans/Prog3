using System;
using System.Collections.Generic;
using System.Text;

namespace Winkel
{
    class Winkel
    {
        public delegate void VerkoopProductEventHandler(object source, WinkelEventArgs meta);
        public event VerkoopProductEventHandler Verkoop;
        public void VerkoopProduct(Bestelling bestelling)
        {
            OnVerkoop(bestelling);
        }

       
        protected virtual void OnVerkoop(Bestelling bestelling)
        {
            if(Verkoop != null)
            {
                Verkoop(this,new WinkelEventArgs() {Bestelling = bestelling});
            }
        }

    }

    public class WinkelEventArgs: EventArgs
    {
        public Bestelling Bestelling { get; set; }
    }
}
