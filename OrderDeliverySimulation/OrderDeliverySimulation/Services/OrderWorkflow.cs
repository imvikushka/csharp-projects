using OrderDeliverySimulation.Interfaces;
using OrderDeliverySimulation.Models;

namespace OrderDeliverySimulation.Services;

public class OrderWorkflow
{
    public readonly OrderStatusManager _orderStatusManager;
    public readonly IPaymentService _paymentService;
    
    public OrderWorkflow(OrderStatusManager statusManager, IPaymentService paymentService)
    {
        _orderStatusManager = statusManager;
        _paymentService = paymentService;
    }
    
    public bool PaymentMenu(Order order)
    {
        while (true)
        {
            Console.WriteLine("1. Pay order");
            Console.WriteLine("2. Cancel order");

            var choice = Console.ReadLine();

            if (choice == "1")
            {
                if (_paymentService.PayOrder(order))
                    return true;
            }
            else if (choice == "2")
            {
                _orderStatusManager.ChangeStatus(order, OrderStatus.Cancelled);
                return false;
            }
        }
    }
}