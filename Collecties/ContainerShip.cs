using System;
using System.Collections.Generic;
using System.Text;

namespace Collecties
{
    class ContainerShip : VrachtShip
    {
        public ContainerShip( int capacity ,float lenght, float width, string name, int cargoWaarde) : base(lenght, width, name, cargoWaarde)
        {
            Capacity = capacity;
        }

        public int Capacity { get; private set; }
        
    }
}
