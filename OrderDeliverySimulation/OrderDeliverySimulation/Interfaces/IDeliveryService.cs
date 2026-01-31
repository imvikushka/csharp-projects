using OrderDeliverySimulation.Models;

namespace OrderDeliverySimulation.Interfaces;

public interface IDeliveryService
{
    Task<Order> Deliver(Order order);
}