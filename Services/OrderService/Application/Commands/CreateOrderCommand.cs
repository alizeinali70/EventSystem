namespace EventSystem.OrderService.Application.Commands;

internal sealed record CreateOrderCommand
(
    string ProductName,
    int Quantity
    );
