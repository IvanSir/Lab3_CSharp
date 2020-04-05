using System;

namespace Lab3_CSharp
{
    class Vehicle
    {
        static int id = 0;
        int speed { get; set; }
        int wheels { get; set; }
        int seats { get; set; }

        int price { get; set; }
        public Vehicle(int speed = 60, int wheels = 4, int seats = 4,int price = 1000)
        {
            id++;
            this.speed = speed;
            this.wheels = wheels;
            this.seats = seats;
            this.price = price;
        }

        public void WriteId()
        {
            Console.WriteLine("This vehicle's id in garage is {0} ", id);
        }


        public void WriteSpeed()
        {
            Console.WriteLine("This vehicle's speed is {0} km/h",speed);
        }
        public void WriteWheels()
        {
            Console.WriteLine("This vehicle has {0} wheels", wheels);
        }

        public void WriteSeats()
        {
            Console.WriteLine("This vehicle has {0} seats", seats);
        }

        public void WritePrice()
        {
            Console.WriteLine("This vehicle's price is {0}$", price);
        }

        public void WriteVehicleInfo()
        {
            WriteSpeed();
            WriteWheels();
            WriteSeats();
            WritePrice();
        }
    }

    class Garage
    {
        Vehicle[] vehicle;

        public Garage(int n)
        {
            vehicle = new Vehicle[n];
        }
        public Vehicle this[int index]
        {
            get
            {
                return vehicle[index];
            }
            set
            {
                vehicle[index] = value;
            }
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage(2);
            Vehicle car = new Vehicle();
            Vehicle bike = new Vehicle(120, 2, 2, 7000);
    

                garage[0] = car;
            garage[1] = bike;
            garage[0].WriteId();
            garage[1].WriteSpeed();
            
        }
    }
}
