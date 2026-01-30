using OrderDeliverySimulation.Models;
using OrderDeliverySimulation.Services;

namespace OrderDeliverySimulation.Interfaces;

public interface IPaymentService
{
    Order PayOrder(Order order);
}