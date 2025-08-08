/*
 * Person Greeting Application
 * 
 * This program demonstrates fundamental Object-Oriented Programming (OOP) concepts in C#,
 * including classes, objects, properties, methods, and constructors.
 * 
 * Key Features:
 * - Person class with encapsulated properties
 * - Constructor for object initialization
 * - Instance method for behavior
 * - Simple console output
 * 
 * The program creates a Person object and displays a greeting message with their details.
 * 
 * To compile and run:
 * 1. Ensure .NET SDK is installed
 * 2. Navigate to project directory in terminal
 * 3. Execute: `dotnet run`
 */

using System;

namespace GreetingsApp // Namespace declaration for organizing code
{
    class Person // Class definition for Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age) // Constructor to initialize the properties
        {
            Name = name;
            Age = age;
        }

        public void Greet() // Method to greet the person
        {
            Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
        }
    }

    class Program // Main class containing the entry point of the application
    {
        static void Main(string[] args) // Main method where the program execution starts
        {
            Person person = new Person("William", 22); // Create a new Person instance- you can also do - var person = new Person("William", 22);
            person.Greet();
        }
    }
} 