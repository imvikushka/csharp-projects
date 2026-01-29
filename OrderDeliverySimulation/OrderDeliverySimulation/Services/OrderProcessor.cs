using OrderDeliverySimulation.Interfaces;
using OrderDeliverySimulation.Models;

namespace OrderDeliverySimulation.Services;

public class OrderProcessor
{
    public readonly Order _order;
    public readonly IOrderValidator _validator;
    
    public OrderProcessor(Order order, IOrderValidator orderValidator)
    {
        _order = order;
        _validator = orderValidator;
    }
    
    public Order Process()
    {
        return _validator.ValidateOrder(_order);
    }
}