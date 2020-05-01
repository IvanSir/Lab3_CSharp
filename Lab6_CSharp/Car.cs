using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace _3cSharp
{
    public enum CarType {HatchBack= 1, Sedan, Wagon};
    struct Dimension
    {
        public int height;
        public int weight;
        public int length;
        public Dimension(int Hght, int wght, int lngth)
        {

            
            height = Hght;
            weight = wght;
            length = lngth;

        }
    }
    class Car : Vehicle, IMovable,IComparable
    {
        public int Fuel { get; set; }

        public int MaxFuel { get; set; }
        public int Consumption { get; set; }
        public CarType TypeOfCar { get; set; }
        public Dimension Dimensions { get; set; }

        public Car(int fuel = 10, int maxFuel = 100, int consumption = 10, CarType cartype = (CarType)1, 
            int height = 2, int length = 2, int weight = 50, int speed = 60, int wheels = 4, string color = "white",bool isBroken = false, int distance = 0 ) 
                : base("car", speed,wheels,color,isBroken,distance) 
        {
            Dimensions = new Dimension(height,weight,length);
            Fuel = (fuel > maxFuel) ? maxFuel: fuel;
            MaxFuel = maxFuel;
            Consumption = consumption;
            TypeOfCar = cartype;
        } 

        public new virtual void  Ride()
        {
            
            
            if (Fuel <= 0)
            {
                Console.WriteLine("You are out of fuel.");
                Console.ReadKey();
                return;
            }
            if (IsBroken)
            {
                Console.WriteLine("This Vehicle is broken, repair it first");
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
                Console.WriteLine("Your vehicle was broken.");
                Console.ReadKey();
            }

            Fuel -= Consumption;

           
            if (Fuel <= 0)
            {
                Console.Clear();
                Console.WriteLine("Out of fuel");
                Console.ReadKey();
            }

        }

        public override void FillFuel()
        {
            Console.Clear();
            Fuel = MaxFuel; ;
            Console.WriteLine("You are ready to drive. Now you have {0} L",Fuel);
            Console.ReadKey();

        }

    

        public virtual Car AddNewVehicle()
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

            Console.WriteLine("Fuel(in L) : ");
            NumberCheck(Console.ReadLine(),out int fuel);

            Console.WriteLine("Maximum Fuel(in L) : ");

            NumberCheck(Console.ReadLine(), out int maxFuel);

            Console.WriteLine("Fuel Consumption : ");
            NumberCheck(Console.ReadLine(), out int consumption);

            Console.WriteLine("Height : ");
            NumberCheck(Console.ReadLine(), out int height);
            
            Console.WriteLine("Length : ");
            NumberCheck(Console.ReadLine(), out int length);
            
            Console.WriteLine("Weight : ");
            NumberCheck(Console.ReadLine(), out int weight);

            return new Car(fuel,maxFuel,consumption,CarType.HatchBack,height,length,weight,speed,wheels,color,izBroken,distance);
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
           
            Console.WriteLine("Fuel level : {0}\nMaximum Fuel : {1}\nFuel Consumption : {2}\nDimensions :" +
                "length : {3}, height : {4}, weight : {5}\n",Fuel,MaxFuel,Consumption,Dimensions.length,Dimensions.height,Dimensions.weight);
        }

        public override void InfoCorrect()
        {

            Console.WriteLine("What exactly do you want to correct : \n1 - Color\n2 - Wheels\n3 - Speed\n4 - Distance\n5 - Condtition\n6 - Fuel\n7 - Max Fuel\n8 - Fuel Consumption");

            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.D1: Console.WriteLine("Correct color is : "); Color = Console.ReadLine(); Console.Clear(); break;
                case ConsoleKey.D2: Console.WriteLine("Correct amount of wheels is : "); NumberCheck(Console.ReadLine(), out int wheel); Wheels = wheel; Console.Clear(); break;
                case ConsoleKey.D3: Console.WriteLine("Correct speed is : "); NumberCheck(Console.ReadLine(), out int speed); Speed = speed;Console.Clear(); break;
                case ConsoleKey.D4: Console.WriteLine("Correct distance is : "); NumberCheck(Console.ReadLine(), out int dist); Distance = dist; Console.Clear(); break;
                case ConsoleKey.D5: Console.WriteLine("Correct condition is : "); IsBroken = DefineBool(Console.ReadLine()); Console.Clear(); break;
                case ConsoleKey.D6: Console.WriteLine("Correct Fuel is : "); NumberCheck(Console.ReadLine(),out int fuel); Fuel = (fuel > MaxFuel) ? MaxFuel : fuel; Console.Clear(); break;
                case ConsoleKey.D7: Console.WriteLine("Correct Maximum Fuel is : "); NumberCheck(Console.ReadLine(),out int maxfuel); MaxFuel = maxfuel; Console.Clear(); break;
                case ConsoleKey.D8: Console.WriteLine("Correct Fuel consumption is : ");NumberCheck(Console.ReadLine(), out int cons); Consumption = cons; Console.Clear(); break;
            }
        }

        public int CompareTo(object obj)
        {
            Car car = obj as Car;
           
            return this.Fuel.CompareTo(car.Fuel);
        }
    }
}
