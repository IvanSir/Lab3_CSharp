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
                Console.WriteLine("Choose the vehicle by its id (from 0 to {0})", size-1);
                for (int i = 0; i < size; i++)
                {
                    Console.Write($"№ {i} - ");
                    garage[i].PrintInfo();
                }
                Vehicle.NumberCheck(Console.ReadLine(), out index);
            } while (index >= size);

            Console.Clear();

        }

        static public void ChooseAdd(List<Vehicle> garage,VolvoXC70 volvo, Vehicle vehicle, Car car, VolkswagenGolf golf, ChevroletMalibu chevrolet)
        {
            Console.WriteLine("What vehicle do you want to add : \n1 - Vehicle\n2 - Car\n3 - VolvoXC70\n4 - Volkswagen Golf\n5 - ChevroletMalibu\n6 - Exit ");
            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.D1: Console.Clear(); garage.Add(vehicle.AddNewVehicle()); Console.Clear(); break;

                case ConsoleKey.D2: Console.Clear(); garage.Add(car.AddNewVehicle()); Console.Clear(); break;

                case ConsoleKey.D3: Console.Clear(); garage.Add(volvo.AddNewVehicle()); Console.Clear(); break;

                case ConsoleKey.D4: Console.Clear(); garage.Add(golf.AddNewVehicle()); Console.Clear(); break;

                case ConsoleKey.D5: Console.Clear(); garage.Add(chevrolet.AddNewVehicle()); Console.Clear(); break;

                case ConsoleKey.D6: return;
            }
        }



        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle();
            List<Vehicle> garage = new List<Vehicle>();
            Car car = new Car();
            VolkswagenGolf golf = new VolkswagenGolf(100,true,"blue",10);
            VolvoXC70 volvo = new VolvoXC70(50, true, "white", 100);
            ChevroletMalibu chevrolet = new ChevroletMalibu(0, false, "Orange", 20);
            garage.Add(car);
            garage.Add(golf);
            garage.Add(volvo);
            garage.Add(chevrolet);
            
            int index;
            do
            {
                Console.WriteLine("Your garage : \n1 - Add\n2 - Info about my vehicles\n3 - Throw Vehicle Away\n4 - Correct info\n5 - Test Drive\n6 - Repair\n7 - Fill Fuel\n8 - Exit");
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.D1: Console.Clear(); ChooseAdd(garage, volvo, vehicle, car, golf, chevrolet); Console.Clear(); break;
                   
                    case ConsoleKey.D2: Console.Clear(); AllVehicleInfo(garage); Console.ReadKey(); Console.Clear(); break;
                    
                    case ConsoleKey.D3: Console.Clear(); VehicleChoice(garage, out index); garage.Remove(garage[index]); Console.Clear(); break;
                    
                    case ConsoleKey.D4: Console.Clear(); VehicleChoice(garage, out index); garage[index].PrintInfo(); garage[index].InfoCorrect(); Console.Clear(); break;
                    
                    case ConsoleKey.D5: Console.Clear(); VehicleChoice(garage, out index); garage[index].Ride(); Console.Clear(); break;
                    
                    case ConsoleKey.D6: Console.Clear(); VehicleChoice(garage, out index); garage[index].Repair();Console.Clear(); break;
                    
                    case ConsoleKey.D7: Console.Clear(); VehicleChoice(garage, out index); garage[index].FillFuel(); Console.Clear(); break;
                    
                    case ConsoleKey.D8: return;
                    
                    default: Console.Clear(); break;
                }

            } while (true);


        }
    }
}
