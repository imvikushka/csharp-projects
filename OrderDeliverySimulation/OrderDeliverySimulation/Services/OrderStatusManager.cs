using OrderDeliverySimulation.Models;

namespace OrderDeliverySimulation.Services;

public class OrderStatusManager
{
    public OrderStatus ChangeStatus(Order order, OrderStatus status)
    {
        return order.OrderStatus = status;
    }
}