using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _3cSharp
{
    abstract class Vehicle 
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

        public virtual void PrintInfo()
        {
            Console.WriteLine("Type : {0}\nColor : {1}\nWheels : {2}\nSpeed : {3}\nDistance : {4}\n{5}", Type, Color, Wheels, Speed, Distance, Condition());
        }

       public virtual void FillFuel() { }

        public void Ride() { }

        public virtual void Repair()
        {
            Console.WriteLine("Oh, look at what you've done... Okay give me some time. I'll try to repair this junk");
            IsBroken = false;
            Console.ReadKey();
        }

        public virtual void InfoCorrect()
        {
            Console.WriteLine("What exactly do you want to correct : \n1 - Type\n2 - Color\n3 - Wheels\n4 - Speed\n5 - Distance\n6 - Condtition\n7 - Exit");

            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.D1: Console.WriteLine("Correct type is : "); Type = Console.ReadLine(); Console.Clear(); break;
                case ConsoleKey.D2: Console.WriteLine("Correct color is : "); Color = Console.ReadLine(); Console.Clear(); break;
                case ConsoleKey.D3: Console.WriteLine("Correct amount of wheels is : "); Wheels = int.Parse(Console.ReadLine()); Console.Clear(); break;
                case ConsoleKey.D4: Console.WriteLine("Correct speed is : "); Speed = int.Parse(Console.ReadLine()); Console.Clear(); break;
                case ConsoleKey.D5: Console.WriteLine("Correct distance is : "); Distance = int.Parse(Console.ReadLine()); Console.Clear(); break;
                case ConsoleKey.D6: Console.WriteLine("Correct condition is : "); IsBroken = bool.Parse(Console.ReadLine()); Console.Clear(); break;
                default: return;
            }
        }

        static public void NumberCheck(string str, out int number)
        {

            if (int.TryParse(str, out number) && number >= 0)
                return;
            Console.WriteLine("Invalid number will be replaced with 0");
            Console.ReadKey();

            

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
