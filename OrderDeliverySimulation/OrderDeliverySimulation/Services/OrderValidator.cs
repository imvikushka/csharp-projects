using OrderDeliverySimulation.Interfaces;
using OrderDeliverySimulation.Models;

namespace OrderDeliverySimulation.Services;

public class OrderValidator
{
    public Order ValidateOrder(Order order)
    {
        if (order.CustomerName.Length == 0)
            throw new Exception("Customer name is not valid");
        
        if (!ValidateItem(order.ListOfItems))
            throw new Exception("Invalid order");
        
        if (order.TotalPrice <= 0)
            throw new Exception("Total price is not valid");
        
        return order;
    }

    private bool ValidateItem(List<OrderItem> orderItems)
    {
        foreach (var item in orderItems)
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