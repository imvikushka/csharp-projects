using OrderDeliverySimulation.Interfaces;
using OrderDeliverySimulation.Models;

namespace OrderDeliverySimulation.Services;

public class ItemValidator
{
    public bool ValidateOrderItem(OrderItem orderItem)
    {
        if (orderItem.Quantity <= 0)
                return false;
            
        if (orderItem.Price <= 0)
                return false;
            
        if (orderItem.ProductName.Length == 0)
                return false;
        
        return true;
    }
    
    public bool ValidateOrderItems(Order order)
    {
        foreach (var item in order.ListOfItems)
        {
            if (item.Quantity <= 0)
                return false;
            
            if (item.Price <= 0)
                return false;
            
            if (item.ProductName.Length == 0)
                return false;
        }
        
        return true;
    }
}