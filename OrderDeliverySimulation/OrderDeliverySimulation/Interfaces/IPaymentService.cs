using OrderDeliverySimulation.Models;
using OrderDeliverySimulation.Services;

namespace OrderDeliverySimulation.Interfaces;

public interface IPaymentService
{
    bool PayOrder(Order order);
}