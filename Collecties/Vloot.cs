using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Collecties
{
    class Vloot
    {
        public string Name { get; private set; }
        private HashSet<Ship> ships = new HashSet<Ship>();

        public void VoegSchipToe(Ship ship)
        {
            if (ships.Count < 2)
                ships.Add(ship);
            else
                Console.WriteLine($"Vloot: {this.Name} is vol.");
        }
        public void VerwijderSchip(Ship ship)
        {
            if(ships.Contains(ship))
                ships.Remove(ship);
            else
                Console.WriteLine($"Schip: {this.Name} is niet in vloot: {ship.Name}");
        }
        public Ship ZoektSchip(string naam)
        {
           foreach(Ship ship in ships)
            {
                if (ship.Name == naam)
                    return ship;
            }

            return null;
        }
        public void GeefSchip()
        {
            foreach(Ship ship in ships)
            {
                Console.WriteLine(ship.ToString());
            }
        }


    }


}
