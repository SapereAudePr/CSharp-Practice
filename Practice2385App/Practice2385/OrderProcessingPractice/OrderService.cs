namespace Practice2385.OrderProcessingPractice;

public static class OrderService
{
    public static Result<Order> PlaceOrder(
        string productName, 
        int quantity, 
        decimal pricePerUnit)
    {
        if (string.IsNullOrEmpty(productName))
            return Result<Order>.Failure("Product name cannot be empty");

        if (quantity < 1 || quantity > 100)
            return Result<Order>.Failure("Quantity must be between 1 and 100");

        if (pricePerUnit <= 0)
            return Result<Order>.Failure("Price Per Unit cannot be 0");

        var total = quantity * pricePerUnit;

        if (total > 500)
            total = total * 0.90m;

        var order = new Order(productName, quantity, pricePerUnit, total);

        return Result<Order>.Success(order);
    }
}
