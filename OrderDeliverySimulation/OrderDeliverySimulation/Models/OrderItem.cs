namespace OrderDeliverySimulation.Models;

public class OrderItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    
    public OrderItem(int id, string name, decimal price, int quantity)
    {
        ProductId = id;
        ProductName = name;
        Price = price;
        Quantity = quantity;
    }
}