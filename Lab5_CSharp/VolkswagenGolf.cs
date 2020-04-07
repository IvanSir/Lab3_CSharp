using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3cSharp
{
    class VolkswagenGolf : Car
    {
        public VolkswagenGolf(int fuel,bool isBroken, string color, int distance) : base(fuel, isBroken: isBroken, color: color, length: 2, height: 2, weight: 100, distance: distance)
        {
            Speed = 50;
            MaxFuel = 120;
            Consumption = 7;
            TypeOfCar = CarType.Sedan;
            Wheels = 4;

        }

        public override void PrintInfo()
        {
            Console.WriteLine("Car : Volkswagen Golf");
            Console.WriteLine("Type : "+TypeOfCar);
            base.PrintInfo();
        }

        public override Vehicle AddNewVehicle()
        {
            Console.WriteLine("Color : ");
            string color = Console.ReadLine();
            Console.WriteLine("Distance : ");
            NumberCheck(Console.ReadLine(), out int distance);
            Console.WriteLine("Fuel(in L) : ");
            NumberCheck(Console.ReadLine(), out int fuel);
            bool izBroken = DefineBool(Console.ReadLine());
            return new VolkswagenGolf(fuel,izBroken,color,distance);
        }
    }
}
