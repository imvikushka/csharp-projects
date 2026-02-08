namespace OrderDeliverySimulation.Models;

public class OrderProcessingResult
{
    public Order Order { get; }
    public bool IsSuccess { get; }
    public string Message { get; }

    public OrderProcessingResult(Order order, bool isSuccess, string message)
    {
        Order = order;
        IsSuccess = isSuccess;
        Message = message;
    }
}