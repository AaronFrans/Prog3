using System;
using System.Collections.Generic;
using System.Text;

namespace Collecties
{
    class Rederij
    {
        public string Name { get; private set; }
        private SortedSet<Vloot> Havens = new SortedSet<Vloot>(new VlootComparer());
        public Rederij(string name)
        {
            Name = name;
        }
        public void ToonVloten()
        {
            foreach (Vloot vloot in Havens)
            {
                vloot.GeefSchip();
            }
        }
        public void TotaalCargoWaarde()
        {
            int TotaalCargo = 0;
            foreach (Vloot vloot in Havens)
            {
                foreach (Ship ship in vloot.Ships)
                {
                    if (ship is ContainerShip)
                    {

                        TotaalCargo += ((ContainerShip)ship).Capacity;
                    }
                }
            }
        }
        public void GeefHavens()
        {
            foreach(Vloot vloot in Havens)
            {
                Console.WriteLine($"{vloot.Name}"); 
            }
        }
        public void VoegVloodToe(Vloot vloot)
        {
            if(Havens.Contains(vloot) != true)
            Havens.Add(vloot);
            else
                Console.WriteLine($"Rederij: {this.Name} bevat haven: {vloot.Name}");
        }
        public void VoegHavenToe(Ship ship)
        {
            VoegVloodToe(ship.vloot);
        }
        public void VeranderSchipVanVloot(string shipNaam, string vlootNaam)
        {
            Vloot vlootToMoveTo = null;
            Ship shipToMove = null;
            foreach (Vloot vloot in Havens)
            {
                if (vloot.Name == vlootNaam)
                    vlootToMoveTo = vloot;
            }

            foreach (Vloot vloot in Havens)
            {
                foreach (Ship ship in vloot.Ships)
                {
                    if (ship.Name == shipNaam)
                        shipToMove = ship;
                }
            }
            vlootToMoveTo.VoegSchipToe(shipToMove);
            shipToMove.vloot.VerwijderSchip(shipToMove);
        }

    }
}
