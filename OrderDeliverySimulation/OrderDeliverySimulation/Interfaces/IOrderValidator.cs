using OrderDeliverySimulation.Models;

namespace OrderDeliverySimulation.Interfaces;

public interface IOrderValidator
{
    Order ValidateOrder(Order order);
}