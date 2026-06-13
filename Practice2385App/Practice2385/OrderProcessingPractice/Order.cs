namespace Practice2385.OrderProcessingPractice;

public record Order(
    string ProductName,
    int Quantity,
    decimal PricePerUnit,
    decimal TotalPrice);
