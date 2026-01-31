using OrderDeliverySimulation.Interfaces;
using OrderDeliverySimulation.Models;

namespace OrderDeliverySimulation.Services;

public class OrderProcessor
{
    public readonly Order _order;
    public readonly OrderValidator _validator;
    public readonly IPaymentService _paymentService;
    public readonly IDeliveryService _deliveryService;
    
    public OrderProcessor(
        Order order, 
        OrderValidator orderValidator, 
        IPaymentService paymentService,
        IDeliveryService deliveryService)
    {
        _order = order;
        _validator = orderValidator;
        _paymentService = paymentService;
        _deliveryService = deliveryService;
    }

    public async Task<Order> Process()
    {
        var validOrder = _validator.ValidateOrder(_order); 
        var paidOrder = _paymentService.PayOrder(validOrder);
        var deliveredOrder = await _deliveryService.Deliver(paidOrder);
        
        return deliveredOrder;
    }
}