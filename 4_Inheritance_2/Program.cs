/*
 * Example: Inheritance in C# with Constructors, Protected Members, and Polymorphism.
 *
 * Scenario:
 * - Base class Vehicle with shared properties and methods.
 * - Derived classes Car and Truck with their own overrides and extra properties.
 * - Demonstrates:
 *      - Protected fields
 *      - Virtual and override methods
 *      - Calling base class methods from derived classes
 *      - Polymorphic behavior through base class references
 */

using System;
using System.Collections.Generic;

namespace VehicleInheritance
{
    // Base class
    public class Vehicle
    {
        public string Brand { get; set; }
        protected int Speed; // Protected: accessible to derived classes

        public Vehicle(string brand, int speed)
        {
            Brand = brand;
            Speed = speed;
        }

        // Virtual method - can be overridden
        public virtual void Start()
        {
            Console.WriteLine($"{Brand} is starting...");
        }

        public virtual void Accelerate()
        {
            Speed += 10;
            Console.WriteLine($"{Brand} accelerates to {Speed} km/h.");
        }
    }

    // Derived class Car
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }

        public Car(string brand, int speed, int doors)
            : base(brand, speed) // Call base constructor
        {
            NumberOfDoors = doors;
        }

        public override void Start()
        {
            Console.WriteLine($"Car {Brand} with {NumberOfDoors} doors is starting with a key...");
        }

        public override void Accelerate()
        {
            Speed += 20; // Faster acceleration for cars
            Console.WriteLine($"Car {Brand} zooms to {Speed} km/h.");
        }
    }

    // Derived class Truck
    public class Truck : Vehicle
    {
        public int LoadCapacity { get; set; }

        public Truck(string brand, int speed, int capacity)
            : base(brand, speed)
        {
            LoadCapacity = capacity;
        }

        public override void Start()
        {
            Console.WriteLine($"Truck {Brand} with {LoadCapacity}kg capacity is starting with a heavy engine...");
        }

        public override void Accelerate()
        {
            Speed += 5; // Slower acceleration for trucks
            Console.WriteLine($"Truck {Brand} rumbles to {Speed} km/h.");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a list of vehicles (polymorphism)
            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Car("Toyota", 0, 4),
                new Truck("Volvo", 0, 10000)
            };

            foreach (var vehicle in vehicles)
            {
                vehicle.Start();       // Calls overridden Start() based on type
                vehicle.Accelerate();  // Calls overridden Accelerate()
                Console.WriteLine();
            }
        }
    }
}
