using System;

namespace Part2_InheritanceAndOverriding
{
    class Vehicle
    {
        protected int speed;
        protected int fuel;

        public Vehicle(int speed = 0, int fuel = 50)
        {
            this.speed = speed;
            this.fuel = fuel;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"[Vehicle] speed={speed}, fuel={fuel}");
        }

        public virtual void Drive()
        {
            fuel -= 5;
            Console.WriteLine("Vehicle is moving...");
        }
    }

    class Car : Vehicle
    {
        private int passengers;

        public Car(int speed = 0, int fuel = 50, int passengers = 1)
            : base(speed, fuel)
        {
            this.passengers = passengers;
        }

        public override void Drive()
        {
            fuel -= 10;
            Console.WriteLine("Car is moving with passenger");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"[Car] speed={speed}, fuel={fuel}, passengers={passengers}");
        }
    }

    class Truck : Vehicle
    {
        private int cargoWeight;

        public Truck(int speed = 0, int fuel = 50, int cargoWeight = 1000)
            : base(speed, fuel)
        {
            this.cargoWeight = cargoWeight;
        }

        public override void Drive()
        {
            fuel -= 15;
            Console.WriteLine("Truck is moving with cargo");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"[Truck] speed={speed}, fuel={fuel}, cargoWeight={cargoWeight}");
        }
    }

    class Program
    {
        static void Main()
        {
            Vehicle v = new Vehicle(speed: 40, fuel: 60);
            Vehicle c = new Car(speed: 50, fuel: 70, passengers: 4);
            Vehicle t = new Truck(speed: 30, fuel: 80, cargoWeight: 3000);

            Vehicle[] all = { v, c, t }; // base-class references

            foreach (var veh in all)
            {
                veh.Drive();     // calls the most-derived override
                veh.ShowInfo();  // likewise
                Console.WriteLine();
            }

            Console.WriteLine("Here: base refs + virtual dispatch => derived overrides run at runtime.");
        }
    }
}
