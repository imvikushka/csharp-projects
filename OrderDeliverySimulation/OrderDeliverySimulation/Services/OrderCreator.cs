using System.Runtime.Intrinsics.Wasm;
using OrderDeliverySimulation.Models;

namespace OrderDeliverySimulation.Services;

public class OrderCreator
{
    private int _nextItemId = 1;
    private List<OrderItem> orderItems = new();
    private List<Order> orders = new();
    
    public List<Order> OrderMenu (ItemCreator itemCreator)
    {
        while (true)
        {
            Console.Clear();
            
            Console.WriteLine("\t=== ORDER CREATOR ===");
            Console.WriteLine("1. Add Order");
            Console.WriteLine("2. Finish");
            
            Console.WriteLine($"Quantity of orders: {orders.Count}");
            
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                orderItems = itemCreator.CreateListOfItems();
                orders.Add(CreateOrder(orderItems));
            } else if (choice == "2")
            {
                return orders;
            }
        }
    }

    private Order CreateOrder(List<OrderItem> orderItems)
    {
        Console.Clear();
        
        Console.WriteLine("=== ORDER CONFIRMATION ===");
        Console.WriteLine("Enter your name:");
        
        var customerName = Console.ReadLine();

        return new Order()
        {
            OrderId = _nextItemId++,
            CustomerName = customerName,
            CreatedAt = DateTime.Now,
            OrderStatus = OrderStatus.Created,
            ListOfItems = orderItems,
            TotalPrice = orderItems.Sum(item => item.Price * item.Quantity)
        };
    }
}