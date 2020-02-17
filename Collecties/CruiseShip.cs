using System;
using System.Collections.Generic;
using System.Text;

namespace Collecties
{
    class CruiseShip : Ship
    {
        public CruiseShip(int nrOfPassenger, float lenght, float width, string name) : base(lenght, width, name)
        {
            NrOfPassenger = nrOfPassenger;
        }

        public int NrOfPassenger { get; private set; }
        public override string ToString()
        {
            return base.ToString() + $"Aantal passagiers: {NrOfPassenger} personen\n";
        }

    }
}
