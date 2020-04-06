using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _3cSharp
{
    class Vehicle
    {
        public string Type { get; set; }
        public int Speed { get; set; }
        public int Wheels { get; set; }
        public string Color { get; set; }

        public bool IsBroken { get; set; }

        public int Distance { get; set; }

        public Vehicle(string type = "car", int speed = 60, int wheels = 4, string color = "white", bool isBroken = false, int distance = 0)
        {
            Type = type;
            Speed = speed;
            Wheels = wheels;
            Color = color;
            IsBroken = isBroken;
            Distance = distance;
        }

        public string Condition()
        {
            return IsBroken ? "This vehicle is Broken." : "It's not broken for now";
        }

        public void PrintInfo()
        {
            Console.WriteLine("Type : {0}\nColor : {1}\nWheels : {2}\nSpeed : {3}\nDistance : {4}\n{5}\n", Type, Color, Wheels, Speed, Distance, Condition());
        }

        static public Vehicle AddNewVehicle()
        {
            Console.WriteLine("Type : ");
            string type = Console.ReadLine();
            Console.WriteLine("Color : ");
            string color = Console.ReadLine();
            Console.WriteLine("Wheels : ");
            int wheels;
            NumberCheck(Console.ReadLine(), out wheels);
            Console.WriteLine("Speed : ");
            int speed;
            NumberCheck(Console.ReadLine(),out speed);
            Console.WriteLine("Distance : ");
            int distance;
            NumberCheck(Console.ReadLine(), out distance);
            Console.WriteLine("Broken : ");

            string isBroken = (Console.ReadLine());

            bool izBroken = Vehicle.DefineBool(isBroken);

            return new Vehicle(type, speed, wheels, color, izBroken, distance);
        }

        public void Ride(Vehicle vehicle)
        {
            if (vehicle.IsBroken)
            {
                Console.WriteLine("This Vehicle is broken, repair it first");
                Console.ReadKey();
                return;
            }
            Random rand = new Random();

            Console.WriteLine("Riding for 1 hour...");
            Thread.Sleep(1000);
            vehicle.Distance += vehicle.Speed;
            int chance = rand.Next(1, 4);
            vehicle.IsBroken = chance == 2 ? true : false;
            if (vehicle.IsBroken)
            {
                Console.Clear();
                Console.WriteLine("Your vehicle was broken.");
                Console.ReadKey();
            }
        }

        public void Repair(Vehicle vehicle)
        {
            Console.WriteLine("Oh, look at what you've done... Okay give me some time. I'll try to repair this junk");
            vehicle.IsBroken = false;
            Console.ReadKey();
        }

        static public void InfoCorrect(Vehicle vehicle)
        {
            Console.WriteLine("What exactly do you want to correct : \n1 - Type\n2 - Color\n3 - Wheels\n4 - Speed\n5 - Distance\n6 - Condtition\n7 - Exit");

            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.D1: Console.WriteLine("Correct type is : "); vehicle.Type = Console.ReadLine(); Console.Clear(); break;
                case ConsoleKey.D2: Console.WriteLine("Correct color is : "); vehicle.Color = Console.ReadLine(); Console.Clear(); break;
                case ConsoleKey.D3: Console.WriteLine("Correct amount of wheels is : "); vehicle.Wheels = int.Parse(Console.ReadLine()); Console.Clear(); break;
                case ConsoleKey.D4: Console.WriteLine("Correct speed is : "); vehicle.Speed = int.Parse(Console.ReadLine()); Console.Clear(); break;
                case ConsoleKey.D5: Console.WriteLine("Correct distance is : "); vehicle.Distance = int.Parse(Console.ReadLine()); Console.Clear(); break;
                case ConsoleKey.D6: Console.WriteLine("Correct condition is : "); vehicle.IsBroken = bool.Parse(Console.ReadLine()); Console.Clear(); break;
                default: return;
            }
        }

        static public void NumberCheck(string str, out int number)
        {
            if (int.TryParse(str, out number))
                return;
            Console.WriteLine("Invalid number will be replaced with 0");

        }

        static public bool DefineBool(string word)
        {
            word.ToLower();
            while (true)
            {
                switch (word)
                {
                    case "1":
                    case "da":
                    case "да":
                    case "yes":
                    case "yeah":
                    case "yup": return true;
                    case "0":
                    case "net":
                    case "нет":
                    case "no":
                    case "nope": return false;
                    default: Console.WriteLine("Incorrect input will be replaced with false"); return false;
                }

            }
        }
    }
}
