namespace EventSystem.OrderService.Application.Commands;

public record CreateOrderCommand
(
    string ProductName,
    int Quantity
    );
