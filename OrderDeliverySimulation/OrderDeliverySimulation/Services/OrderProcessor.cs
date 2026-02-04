using OrderDeliverySimulation.Interfaces;
using OrderDeliverySimulation.Models;

namespace OrderDeliverySimulation.Services;

public class OrderProcessor
{
    public readonly Order _order;
    public readonly OrderValidator _validator;
    public readonly IDeliveryService _deliveryService;
    public readonly OrderWorkflow _workflow;
    
    public OrderProcessor(
        Order order, 
        OrderValidator orderValidator, 
        IDeliveryService deliveryService,
        OrderWorkflow workflow)
    {
        _order = order;
        _validator = orderValidator;
        _deliveryService = deliveryService;
        _workflow = workflow;
    }

    public async Task<Order> Process()
    {
        var validOrder = _validator.ValidateOrder(_order);
        var paidOrder = _workflow.PaymentMenu(validOrder);
        
        if (!paidOrder)
            return validOrder;
        
        var deliveredOrder = await _deliveryService.Deliver(validOrder);
        
        return deliveredOrder;
    }
}