using OrderDeliverySimulation.Interfaces;
using OrderDeliverySimulation.Models;

namespace OrderDeliverySimulation.Services;

public class DeliveryService : IDeliveryService
{
    public readonly OrderStatusManager _orderStatusManager;
    
    public DeliveryService(OrderStatusManager orderStatusManager)
    {
        _orderStatusManager = orderStatusManager;
    }
    
    public async Task<Order> Deliver(Order order)
    {
        _orderStatusManager.ChangeStatus(order, OrderStatus.Packed);
        Console.WriteLine($"Order status changed to {order.OrderStatus}");
        await Task.Delay(2000);
        
        _orderStatusManager.ChangeStatus(order, OrderStatus.Shipped);
        Console.WriteLine($"Order status changed to {order.OrderStatus}");
        await Task.Delay(5000);
        
        _orderStatusManager.ChangeStatus(order, OrderStatus.Delivered);
        Console.WriteLine($"Order status changed to {order.OrderStatus}");
        
        return order;
    }
}