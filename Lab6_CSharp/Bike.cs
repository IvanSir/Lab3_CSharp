using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _3cSharp
{
    class Bike : Vehicle, IMovable
    {
        public Bike(int speed = 60, int wheels = 4, string color = "white", bool isBroken = false, int distance = 0)
                : base("bike", speed, wheels, color, isBroken, distance)
        {

        }


        public new void Ride()
        {


            if (IsBroken)
            {
                Console.WriteLine("The Bike is broken, repair it first");
                Console.ReadKey();
                return;
            }

            Random rand = new Random();

            Console.WriteLine("Riding for 1 hour...");
            Thread.Sleep(1000);
            Distance += Speed;


            int chance = rand.Next(1, 4);
            IsBroken = chance == 2 ? true : false;
            if (IsBroken)
            {
                Console.Clear();
                Console.WriteLine("The Bike was broken.");
                Console.ReadKey();
            }



        }




        public Bike AddNewVehicle()
        {
            Console.WriteLine("Color : ");
            string color = Console.ReadLine();
            Console.WriteLine("Wheels : ");

            NumberCheck(Console.ReadLine(), out int wheels);
            Console.WriteLine("Speed : ");

            NumberCheck(Console.ReadLine(), out int speed);
            Console.WriteLine("Distance : ");

            NumberCheck(Console.ReadLine(), out int distance);
            Console.WriteLine("Broken : ");

            bool izBroken = DefineBool(Console.ReadLine());

            return new Bike( speed, wheels, color, izBroken, distance);
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
        }

        public override void InfoCorrect()
        {

            Console.WriteLine("What exactly do you want to correct : \n1 - Color\n2 - Wheels\n3 - Speed\n4 - Distance\n5 - Condtition\n6 - Fuel\n7 - Max Fuel\n8 - Fuel Consumption");

            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.D1: Console.WriteLine("Correct color is : "); Color = Console.ReadLine(); Console.Clear(); break;
                case ConsoleKey.D2: Console.WriteLine("Correct amount of wheels is : "); NumberCheck(Console.ReadLine(), out int wheel); Wheels = wheel; Console.Clear(); break;
                case ConsoleKey.D3: Console.WriteLine("Correct speed is : "); NumberCheck(Console.ReadLine(), out int speed); Speed = speed; Console.Clear(); break;
                case ConsoleKey.D4: Console.WriteLine("Correct distance is : "); NumberCheck(Console.ReadLine(), out int dist); Distance = dist; Console.Clear(); break;
                case ConsoleKey.D5: Console.WriteLine("Correct condition is : "); IsBroken = DefineBool(Console.ReadLine()); Console.Clear(); break;
            }
        }


    }
}
