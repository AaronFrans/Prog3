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

            Vloot vloot = new Vloot("Vloot test");
            vloot.VoegSchipToe(shipTest);
            vloot.GeefSchip();
            vloot.VoegSchipToe(cruiseShipTest);
            vloot.GeefSchip();
            vloot.VoegSchipToe(roRoShipTest);
            vloot.VerwijderSchip(roRoShipTest);
            vloot.VerwijderSchip(shipTest);
            vloot.GeefSchip();
            Console.WriteLine(vloot.ZoektSchip(cruiseShipTest.Name).ToString());

        }
    }
}
 