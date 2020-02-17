using System;
using System.Collections.Generic;
using System.Text;

namespace Collecties
{
    class ContainerShip : VrachtShip
    {
        public ContainerShip( int capacity ,float lenght, float width, string name) : base(lenght, width, name)
        {
            CargoWaarde = "kg";
            Capacity = capacity;
        }

        public int Capacity { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"Cargo: {Capacity} {CargoWaarde}\n";
        }

    }
}
