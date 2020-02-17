using System;
using System.Collections.Generic;
using System.Text;

namespace Collecties
{
    class RoRoShip : VrachtShip
    {
        public RoRoShip(int nrOfCars , int nrOfTrucks, float lenght, float width, string name) : base(lenght, width, name)
        {
            NrOfTrucks = nrOfTrucks;
            NrOfCars = nrOfCars;
            CargoWaarde = "Voortuigen";
        }

        public int NrOfCars { get; private set; }
        public int NrOfTrucks { get; private set; }
        public override string ToString()
        {
            return base.ToString() + $"Auto's: {NrOfCars} {CargoWaarde}, Trucks: {NrOfTrucks}, {CargoWaarde}\n";
        }

    }
}
