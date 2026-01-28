using OrderDeliverySimulation.Interfaces;
using OrderDeliverySimulation.Models;
using OrderDeliverySimulation.Services;

namespace OrderDeliverySimulation;

class Program
{
    static async Task Main(string[] args)
    {
        IOrderService orderService = new OrderService();
        
        List<OrderItem> items = new()
        {
            new OrderItem(1, "Laptop", 59600.00, 1),
            new OrderItem(2, "Phone", 25300.50, 1),
            new OrderItem(3, "Headphones", 6500.40, 1)
        };

        List<Order> orders = new()
        {
            new Order()
            {
                OrderId = 1,
                CustomerName = "John Doe",
                CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                OrderStatus = OrderStatus.Created,
                ListOfItems = items,
                TotalPrice = items.Sum(item => item.Price * item.Quantity)
            }
        };
        
        var result = await orderService.ParseOrder(orders);
    }
}