using System;

namespace Collecties
{
    class Program
    {
        static void Main(string[] args)
        {
            //#region jjosg
            Ship shipTest = new Ship(2.5f, 5, "SS. Bitch");
            Ship vrachtShipTest = new VrachtShip(2.5f, 9, "SS. Boy");
            Ship containerShipTest = new ContainerShip(500, 2.5f, 5, "SS. Kick");
            Ship roRoShipTest = new RoRoShip(50, 100, 2.5f, 5, "SS. My");
            Ship cruiseShipTest = new CruiseShip(299, 2.5f, 5, "SS. Ass");

            //Console.WriteLine(shipTest.ToString());
            //Console.WriteLine(vrachtShipTest.ToString());
            //Console.WriteLine(containerShipTest.ToString());
            //Console.WriteLine(roRoShipTest.ToString());
            //Console.WriteLine(cruiseShipTest.ToString());

            //Vloot vloot = new Vloot("Vloot test");
            //vloot.VoegSchipToe(shipTest);
            //vloot.GeefSchip();
            //vloot.VoegSchipToe(cruiseShipTest);
            //vloot.GeefSchip();
            //vloot.VoegSchipToe(roRoShipTest);
            //vloot.VerwijderSchip(roRoShipTest);
            //vloot.VerwijderSchip(shipTest);
            //vloot.GeefSchip();
            //Console.WriteLine(vloot.ZoektSchip(cruiseShipTest.Name).ToString());
            //#endregion

            //Rederij rederij = new Rederij("Hello");

            //rederij.VoegVloodToe(vloot);


            Console.WriteLine("----------------------------------");
            Console.WriteLine("SCHEPEN TESTEN");
            Console.WriteLine(shipTest);
            Console.WriteLine(vrachtShipTest);
            Console.WriteLine(cruiseShipTest);
            Console.WriteLine(roRoShipTest);
            Console.WriteLine(containerShipTest);
            Console.WriteLine("---------------------------------");
            //Console.WriteLine("VLOOT TESTEN");
            //Vloot vloot = new Vloot("vlootTeFuck");
            //vloot.VoegSchipToe(shipTest);
            //vloot.VoegSchipToe(cruiseShipTest);
            //vloot.VoegSchipToe(roRoShipTest);
            //vloot.GeefSchip();
            //vloot.VerwijderSchip(shipTest);
            //vloot.GeefSchip();
            //vloot.ZoektSchip("cruiseshipKak");
            //Console.WriteLine("---------------------------------");
            Console.WriteLine("REDERIJ TESTEN");
            Rederij umama = new Rederij("umama");
            //vloot objecten aanmaken om toe te voegen aan haven 
            Vloot vlootje1 = new Vloot("vlootje1");
            Vloot vlootje2 = new Vloot("vlootje2");
            vlootje1.VoegSchipToe(shipTest);
            vlootje1.VoegSchipToe(new Ship(2, 4, "kaka"));
            vlootje1.VoegSchipToe(new Ship(3, 2, "pipi"));
            vlootje2.VoegSchipToe(new Ship(2, 5, "kaka2"));
            vlootje2.VoegSchipToe(new Ship(3, 6, "botervlootje"));
            
            umama.VoegVloodToe(vlootje1);
            umama.VoegVloodToe(vlootje2);
            umama.GeefHavens();



        }
    }
}
 