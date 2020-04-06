using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3cSharp
{
    class MainClass
    {
        static void AllVehicleInfo(List<Vehicle> garage)
        {
            foreach(Vehicle vehicle in garage)
            {
                vehicle.PrintInfo();
            }
        }

        static void VehicleChoice(List<Vehicle> garage, out int  index)
        {

            int size = garage.Count();
            do
            {
                Console.WriteLine("Choose the vehicle by its id (from 0 to {0})", size);
                Vehicle.NumberCheck(Console.ReadLine(), out index);
            } while (index >= size);

        }



        static void Main(string[] args)
        {
            Vehicle car = new Vehicle();
            List<Vehicle> garage = new List<Vehicle>();
            garage.Add(car);
            int index;
            do
            {
                Console.WriteLine("Your garage : \n1 - Add\n2 - Info about my vehicles\n3 - Throw Vehicle Away\n4 - Correct info\n5 - Test Drive\n6 - Repair\n7 - Exit");
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.D1: Console.Clear(); garage.Add(Vehicle.AddNewVehicle()); Console.Clear(); break;
                    case ConsoleKey.D2: Console.Clear(); AllVehicleInfo(garage); Console.ReadKey(); Console.Clear(); break;
                    case ConsoleKey.D3: Console.Clear(); VehicleChoice(garage, out index); garage.Remove(garage[index]); Console.Clear(); break;
                    case ConsoleKey.D4: Console.Clear(); VehicleChoice(garage, out index); garage[index].PrintInfo(); Vehicle.InfoCorrect(garage[index]); Console.Clear(); break;
                    case ConsoleKey.D5: Console.Clear(); VehicleChoice(garage, out index); garage[index].Ride(garage[index]); Console.Clear(); break;
                    case ConsoleKey.D6: Console.Clear(); VehicleChoice(garage, out index); garage[index].Repair(garage[index]);Console.Clear(); break;
                    case ConsoleKey.D7: return;
                    default: Console.Clear(); break;
                }

            } while (true);
        }
    }
}
