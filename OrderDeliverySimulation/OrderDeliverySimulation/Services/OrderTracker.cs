using OrderDeliverySimulation.Models;

namespace OrderDeliverySimulation.Services;

public class OrderTracker
{
    public void OrderTracking(List<OrderProcessingResult> results)
    {
        foreach (var result in results)
        {
            Console.WriteLine($"{result.Order.OrderId}, {result.Message}, {result.IsSuccess}");
        }
    }
}