using OrderDeliverySimulation.Models;
using OrderDeliverySimulation.Services;

namespace OrderDeliverySimulation;

class Program
{
    static async Task Main(string[] args)
    {
        var statusManager = new OrderStatusManager();
        var orderCreator = new OrderCreator();
        var itemCreator = new ItemCreator(new ItemValidator());
        var orderTracker = new OrderTracker();
        
        var processor = new OrderProcessor(
            new ItemValidator(),
            new DeliveryService(statusManager),
            new OrderWorkflow(statusManager, new PaymentService(statusManager))
        );

        var orders = orderCreator.OrderMenu(itemCreator);
        
        var results = new List<OrderProcessingResult>();

        foreach (var order in orders)
        {
            var result = await processor.Process(order);
            results.Add(result);
        }
        
        orderTracker.OrderTracking(results);
    }
}