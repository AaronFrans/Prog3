using System;

namespace Collecties
{
    class Program
    {
        static void Main(string[] args)
        {
            Ship shipTest = new Ship(2.5f, 5, "SS. Bitch");
            Ship vrachtShipTest = new VrachtShip(2.5f, 9, "SS. Boy");
            Ship containerShipTest = new ContainerShip(500,2.5f, 5, "SS. Kick");
            Ship roRoShipTest = new RoRoShip(50,100,2.5f, 5, "SS. My");
            Ship cruiseShipTest = new CruiseShip(299,2.5f, 5, "SS. Ass");

            Console.WriteLine(shipTest.ToString());
            Console.WriteLine(vrachtShipTest.ToString());
            Console.WriteLine(containerShipTest.ToString());
            Console.WriteLine(roRoShipTest.ToString());
            Console.WriteLine(cruiseShipTest.ToString());
        }
    }
}
 