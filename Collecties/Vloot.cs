using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Collecties
{
    class Vloot
    {
        public string Name { get; private set; }
        public HashSet<Ship> Ships { get; private set; } = new HashSet<Ship>();

        public Rederij rederij {get; set;}

        public Vloot(string name)
        {
            Name = name;
        }
        public void VoegSchipToe(Ship ship)
        {
            if (Ships.Count < 2)
            {
                Ships.Add(ship);
                ship.vloot = this;
            }

            else
                Console.WriteLine($"Vloot: {Name} is vol.\n");
        }
        public void VerwijderSchip(Ship ship)
        {
            if (Ships.Contains(ship))
            {
                Ships.Remove(ship);
                ship.vloot = null;
            }

            else
                Console.WriteLine($"Schip: {ship.Name} is niet in vloot: {this.Name}\n");
        }
        public Ship ZoektSchip(string naam)
        {
            foreach (Ship ship in Ships)
            {
                if (ship.Name == naam)
                    return ship;
            }

            return null;
        }
        public void GeefSchip()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine($"Vloot: {this.Name}");
            foreach (Ship ship in Ships)
            {
                Console.WriteLine(ship.ToString());
            }
            Console.WriteLine("-----------------------\n");
        }

        public override bool Equals(object obj)
        {
            return obj is Vloot vloot &&
                   Name == vloot.Name &&
                   EqualityComparer<HashSet<Ship>>.Default.Equals(Ships, vloot.Ships);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Ships);
        }
    }


    class VlootComparer: IComparer<Vloot>
    {
        public int Compare(Vloot x, Vloot y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }


}
