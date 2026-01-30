using OrderDeliverySimulation.Interfaces;
using OrderDeliverySimulation.Models;

namespace OrderDeliverySimulation.Services;

public class OrderProcessor
{
    public readonly Order _order;
    public readonly OrderValidator _validator;
    public readonly IPaymentService _paymentService;
    
    public OrderProcessor(
        Order order, 
        OrderValidator orderValidator, 
        IPaymentService paymentService)
    {
        _order = order;
        _validator = orderValidator;
        _paymentService = paymentService;
    }

    public Order Process()
    {
        var validOrder = _validator.ValidateOrder(_order);
        return _paymentService.PayOrder(validOrder);
    }
}