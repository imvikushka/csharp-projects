using OrderDeliverySimulation.Interfaces;
using OrderDeliverySimulation.Models;

namespace OrderDeliverySimulation.Services;

public class OrderProcessor
{
    public readonly ItemValidator _itemValidator;
    public readonly IDeliveryService _deliveryService;
    public readonly OrderWorkflow _workflow;
    
    public OrderProcessor(
        ItemValidator itemValidator, 
        IDeliveryService deliveryService,
        OrderWorkflow workflow
        )
    {
        _itemValidator = itemValidator;
        _deliveryService = deliveryService;
        _workflow = workflow;
    }

    public async Task<OrderProcessingResult> Process(Order order)
    {
        if (!_itemValidator.ValidateOrderItems(order))
            return new OrderProcessingResult(order, false, "Order contains invalid items");

        var isPaid = _workflow.PaymentMenu(order);

        if (!isPaid)
            return new OrderProcessingResult(order, false, "Order was not paid");

        await _deliveryService.Deliver(order);

        return new OrderProcessingResult(order, true, "Order delivered");
    }
}