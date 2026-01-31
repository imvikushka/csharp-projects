using OrderDeliverySimulation.Models;
using OrderDeliverySimulation.Services;

namespace OrderDeliverySimulation;

class Program
{
    static async Task Main(string[] args)
    {
        List<OrderItem> items = new()
        {
            new OrderItem(1, "Laptop", 59600.00m, 1),
            new OrderItem(2, "Phone", 25300.50m, 1),
            new OrderItem(3, "Headphones", 6500.40m, 1)
        };

        var statusManager = new OrderStatusManager();
        
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
            new OrderValidator(),
            new PaymentService(statusManager),
            new DeliveryService(statusManager)
        );
        
        var result = await processor.Process();
    }
}