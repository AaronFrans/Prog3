using System;
using System.Collections.Generic;
using System.Text;

namespace Collecties
{
    class RoRoShip : VrachtShip
    {
        public RoRoShip(int nrOfCars , int nrOfTrucks, float lenght, float width, string name, int cargoWaarde) : base(lenght, width, name, cargoWaarde)
        {
            NrOfTrucks = nrOfTrucks;
            NrOfCars = nrOfCars;
        }

        public int NrOfCars { get; private set; }
        public int NrOfTrucks { get; private set; }

    }
}
