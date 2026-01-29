using OrderDeliverySimulation.Models;
using OrderDeliverySimulation.Services;

namespace OrderDeliverySimulation;

class Program
{
    static void Main(string[] args)
    {
        List<OrderItem> items = new()
        {
            new OrderItem(1, "Laptop", 59600.00m, 1),
            new OrderItem(2, "", 25300.50m, 1),
            new OrderItem(3, "Headphones", 6500.40m, 1)
        };

        var processor = new OrderProcessor(
            new Order()
            {
                OrderId = 1,
                CustomerName = "John Doe",
                CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                OrderStatus = OrderStatus.Created,
                ListOfItems = items,
                TotalPrice = items.Sum(item => item.Price * item.Quantity)
            },
            new OrderValidator()
        );
        
        processor.Process();
    }
}