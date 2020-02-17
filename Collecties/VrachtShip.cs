using System;
using System.Collections.Generic;
using System.Text;

namespace Collecties
{
    class VrachtShip: Ship
    {
        public VrachtShip(float lenght, float width, string name, int cargoWaarde) : base(lenght, width, name)
        {
            CargoWaarde = cargoWaarde;
        }

        public int CargoWaarde { get; private set; }
    }
}
