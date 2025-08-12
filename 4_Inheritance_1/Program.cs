/*
 * Example of inheritance in C#.
 * This program defines a base class Animal and a derived class Dog.
 * The Dog class inherits properties and methods from the Animal class.

    * Key Features:
    * - Base class Animal with a method Eat
    * - Derived class Dog with an additional property Breed and a method Bark
    * - Demonstrates polymorphism by calling methods from the base class
 */

using System;

namespace AnimalInheritance
{
    public class Animal
    {
        public string Name { get; set; }

        public void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }
    }

    public class Dog : Animal
    {
        public string Breed { get; set; }

        public void Bark()
        {
            Console.WriteLine($"{Name} the {Breed} says: Woof woof!");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Dog dog = new Dog
            {
                Name = "Bosco",
                Breed = "German Shepherd"
            };

            // Eating
            dog.Eat();

            // Bark
            dog.Bark();
        }
    }
}
