using OrderDeliverySimulation.Interfaces;
using OrderDeliverySimulation.Models;

namespace OrderDeliverySimulation.Services;

public class PaymentService : IPaymentService
{
    public readonly OrderStatusManager _orderStatusManager;
    
    public PaymentService(OrderStatusManager orderStatusManager)
    {
        _orderStatusManager = orderStatusManager;
    }
    
    public Order PayOrder(Order order)
    {
        Console.WriteLine($"Total order amount: {order.TotalPrice}\nPlease pay for your order.\n");
        string? enteredAmount = Console.ReadLine()?.Trim();

        if (IsPaid(enteredAmount, order))
        {
            _orderStatusManager.ChangeStatus(order, OrderStatus.Paid);
            Console.WriteLine($"{order.OrderId} is successfully paid! Status: {order.OrderStatus}");
        }
        else
        {
            _orderStatusManager.ChangeStatus(order, OrderStatus.Cancelled);
            Console.WriteLine($"Not enough money to pay for the order! Status: {order.OrderStatus}");
        }
        
        return order;
    }

    private bool IsPaid(string? enteredAmount, Order order)
    {
        decimal.TryParse(enteredAmount, out var amount);
        
        if (amount < order.TotalPrice)
            return false;
        
        return true;
    }
}