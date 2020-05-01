using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3cSharp
{
    class MainClass
    {
        static void AllVehicleInfo(List<Car> garage)
        {
            foreach (Car vehicle in garage)
            {
                vehicle.PrintInfo();
            }
        }

        static void BikeInfo(List<Bike> camp)
        {
            foreach( Bike vike in camp)
            {
                vike.PrintInfo();
            }
        }

        static void VehicleChoice(List<Car> garage, out int index)
        {

            int size = garage.Count();
            do
            {
                Console.WriteLine("Choose the vehicle by its id (from 0 to {0})", size - 1);
                for (int i = 0; i < size; i++)
                {
                    Console.Write($"№ {i} - ");
                    garage[i].PrintInfo();
                }
                Vehicle.NumberCheck(Console.ReadLine(), out index);
            } while (index >= size);

            Console.Clear();

        }

        static void BikeChoice(List<Bike> garage, out int index)
        {
            int size = garage.Count();
            do
            {
                Console.WriteLine("Choose the vehicle by its id (from 0 to {0})", size - 1);
                for (int i = 0; i < size; i++)
                {
                    Console.Write($"№ {i} - ");
                    garage[i].PrintInfo();
                }
                Vehicle.NumberCheck(Console.ReadLine(), out index);
            } while (index >= size);

            Console.Clear();

        }

        static void FuelSort(List<Car> garage)
        {

            for (int i = 0; i < garage.Count; i++)
            {
                for (int j = 0; j < garage.Count - 1; j++)
                {
                    if (garage[j].CompareTo(garage[j + 1]) >= 1)
                    {
                        Car b = garage[j]; 
                        garage[j] = garage[j + 1]; 
                        garage[j + 1] = b; 
                    }
                }
            }

        }

        static public void ChooseAdd(List<Car> garage, VolvoXC70 volvo,  Car car, ChevroletMalibu chevrolet, VolkswagenGolf golf, VolkswagenPolo polo)
        {
            Console.WriteLine("What vehicle do you want to add : \n2 - Car\n3 - VolvoXC70\n4 - ChevroletMalibu\n5 - VolkswagenGolf\n6 - VolkswagenPolo\n7 - Exit ");
            switch (Console.ReadKey(false).Key)
            {

                case ConsoleKey.D2: Console.Clear(); garage.Add(car.AddNewVehicle()); Console.Clear(); break;

                case ConsoleKey.D3: Console.Clear(); garage.Add(volvo.AddNewVehicle()); Console.Clear(); break;

                case ConsoleKey.D4: Console.Clear(); garage.Add(chevrolet.AddNewVehicle()); Console.Clear(); break;
                
                case ConsoleKey.D5: Console.Clear(); garage.Add(golf.AddNewVehicle()); Console.Clear(); break;

                case ConsoleKey.D6: Console.Clear(); garage.Add(polo.AddNewVehicle()); Console.Clear(); break;

                case ConsoleKey.D7: return;
            }
        }

        static public void BikeCamp(List<Bike> camp)
        {
            int index;
            do
            {
                Console.WriteLine("Your bike camp : \n1 - Add\n2 - Info\n3 - Throw Away\n4 - Test Drive\n" +
                                      "5 - Repair\n6 - Back");
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.D1: Console.Clear(); camp.Add(camp[0].AddNewVehicle()); Console.Clear(); break;

                    case ConsoleKey.D2: Console.Clear(); BikeInfo(camp); Console.ReadKey(); Console.Clear(); break;

                    case ConsoleKey.D3: Console.Clear(); BikeChoice(camp, out  index); camp.Remove(camp[index]); Console.Clear(); break;

                    case ConsoleKey.D4: Console.Clear(); BikeChoice(camp, out index); camp[index].Ride(); Console.Clear(); break;

                    case ConsoleKey.D5: Console.Clear(); BikeChoice(camp, out index); camp[index].Repair(); Console.Clear(); break;

                    case ConsoleKey.D6: return;

                    default: Console.Clear(); break;
                }

            } while (true);


        }

       



        static void Main(string[] args)
        {
            List<Car> garage = new List<Car>();

            List<Bike> camp = new List<Bike>(); 
            

            Car car = new Car();
            VolkswagenGolf golf = new VolkswagenGolf(100,true,"blue",10);
            VolvoXC70 volvo = new VolvoXC70(50, true, "white", 100);
            ChevroletMalibu chevrolet = new ChevroletMalibu(0, false, "Orange", 20);
            VolkswagenPolo polo = new VolkswagenPolo(2,"yellow");
            Bike bike = new Bike(15, 2, "black", false, 0);

            garage.Add(car);
            garage.Add(volvo);
            garage.Add(chevrolet);
            garage.Add(golf);
            garage.Add(polo);
            camp.Add(bike);
            
            int index;
            do
            {
                Console.WriteLine("Your garage : \n1 - Add\n2 - Info about my cars\n3 - Throw Car Away\n4 - Correct info\n5 - Test Drive\n" +
                                      "6 - Repair\n7 - Fill Fuel\n8 - Go to Bike camp\n9 - Exit");
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.D1: Console.Clear(); ChooseAdd(garage, volvo, car,chevrolet,golf,polo); Console.Clear(); break;
                   
                    case ConsoleKey.D2: Console.Clear(); FuelSort(garage); AllVehicleInfo(garage); Console.ReadKey(); Console.Clear(); break;
                    
                    case ConsoleKey.D3: Console.Clear(); VehicleChoice(garage, out index); garage.Remove(garage[index]); Console.Clear(); break;
                    
                    case ConsoleKey.D4: Console.Clear(); VehicleChoice(garage, out index); garage[index].PrintInfo(); garage[index].InfoCorrect(); Console.Clear(); break;
                    
                    case ConsoleKey.D5: Console.Clear(); VehicleChoice(garage, out index); garage[index].Ride(); Console.Clear(); break;
                    
                    case ConsoleKey.D6: Console.Clear(); VehicleChoice(garage, out index); garage[index].Repair();Console.Clear(); break;
                    
                    case ConsoleKey.D7: Console.Clear(); VehicleChoice(garage, out index); garage[index].FillFuel(); Console.Clear(); break;

                    case ConsoleKey.D8: Console.Clear(); BikeCamp(camp); Console.Clear(); break;

                    case ConsoleKey.D9: return;
                    
                    default: Console.Clear(); break;
                }

            } while (true);


        }
    }
}
