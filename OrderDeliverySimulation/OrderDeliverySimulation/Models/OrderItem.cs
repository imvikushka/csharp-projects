namespace OrderDeliverySimulation.Models;

public class OrderItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    
    public OrderItem(int id, string name, double price, int quantity)
    {
        ProductId = id;
        ProductName = name;
        Price = price;
        Quantity = quantity;
    }
}