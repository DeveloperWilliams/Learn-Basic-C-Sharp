/*
// This code is part of the Food Encapsulation project.
// It demonstrates the use of encapsulation and polymorphism in C#.
// The program defines an abstract base class FoodOrder and derived classes for different food types.
// Each derived class implements the PlaceOrder method to provide specific order details.
*/


using System;

namespace FoodEncapsulation
{
    // Abstract base class
    public abstract class FoodOrder
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }

        public FoodOrder(string orderId, decimal amount)
        {
            OrderId = orderId;
            Amount = amount;
        }

        public abstract void PlaceOrder();
    }

    // PizzaOrder class
    public class PizzaOrder : FoodOrder
    {
        public string Topping { get; set; }

        public PizzaOrder(string orderId, decimal amount, string topping)
            : base(orderId, amount)
        {
            Topping = topping;
        }

        public override void PlaceOrder()
        {
            Console.WriteLine($"Pizza order placed. Order ID: {OrderId}, Amount: {Amount}, Topping: {Topping}");
        }
    }

    // BurgerOrder class
    public class BurgerOrder : FoodOrder
    {
        public string Size { get; set; }

        public BurgerOrder(string orderId, decimal amount, string size)
            : base(orderId, amount)
        {
            Size = size;
        }

        public override void PlaceOrder()
        {
            Console.WriteLine($"Burger order placed. Order ID: {OrderId}, Amount: {Amount}, Size: {Size}");
        }
    }

    // SushiOrder class
    public class SushiOrder : FoodOrder
    {
        public string FishType { get; set; }

        public SushiOrder(string orderId, decimal amount, string fishType)
            : base(orderId, amount)
        {
            FishType = fishType;
        }

        public override void PlaceOrder()
        {
            Console.WriteLine($"Sushi order placed. Order ID: {OrderId}, Amount: {Amount}, Fish Type: {FishType}");
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            FoodOrder[] foodOrders =
            {
                new PizzaOrder("OD1", 100, "Beef"),
                new BurgerOrder("OD2", 150, "Large"),
                new SushiOrder("OD3", 250, "Tilapia")
            };

            foreach (FoodOrder foodOrder in foodOrders)
            {
                foodOrder.PlaceOrder();
            }
        }
    }
}
