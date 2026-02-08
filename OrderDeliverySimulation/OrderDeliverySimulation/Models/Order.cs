namespace OrderDeliverySimulation.Models;

public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public List<OrderItem> ListOfItems { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime CreatedAt { get; set; }
}