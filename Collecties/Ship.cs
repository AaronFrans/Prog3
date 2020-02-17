using System;
using System.Collections.Generic;
using System.Text;

namespace Collecties
{
    class Ship
    {
        public Ship( float lenght, float width , string name )
        {
            Lenght = lenght;
            Width = width;
            Name = name;
        }
        public float Lenght { get;private  set; }
        public float Width { get; private set; }
        public string Name { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Ship ship &&
                   Name == ship.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
        public override string ToString()
        {
            return $"Naam: {Name}\nBreedte: {Width}, Lengte: {Lenght}\n";
        }
    }
}
