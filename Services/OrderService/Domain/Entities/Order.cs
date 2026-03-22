namespace EventSystem.OrderService.Domain.Entities;

internal sealed class Order
{
    public Guid Id { get; private set; }
    public string ProductName { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }

    public Order(string productName,int quantity, decimal price, DateTime createdAt)
    {
        Id = Guid.NewGuid(); 
        ProductName = productName;
        Quantity = quantity;
        Price = price;
        CreatedAt = createdAt;
    }
}
