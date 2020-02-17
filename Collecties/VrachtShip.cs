using System;
using System.Collections.Generic;
using System.Text;

namespace Collecties
{
    class VrachtShip: Ship
    {
        public VrachtShip(float lenght, float width, string name) : base(lenght, width, name)
        {
            CargoWaarde = "Onbepaald";
        }

        public string CargoWaarde { get; protected set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
