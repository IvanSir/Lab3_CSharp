using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3cSharp
{
    class ChevroletMalibu : Car
    {
        public ChevroletMalibu(int fuel, bool isBroken, string color, int distance) : base(fuel,  isBroken: isBroken, color: color, length: 2, height: 2, weight: 100, distance: distance)
        {
            Speed = 90;
            MaxFuel = 90;
            Consumption = 13;
            TypeOfCar = CarType.HatchBack;
            Wheels = 4;

        }
        public override void PrintInfo()
        {
            Console.WriteLine("Car : Chevrolet Malibu");
            Console.WriteLine("Type : " + TypeOfCar);
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
            return new ChevroletMalibu(fuel, izBroken, color, distance);
        }
    }
}
