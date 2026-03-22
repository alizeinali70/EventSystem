using EventSystem.OrderService.Application.Commands;
using EventSystem.OrderService.Application.Interfaces;
using EventSystem.OrderService.Domain.Entities;

namespace EventSystem.OrderService.Application.Handler;

internal sealed class CreateOrderHandler(IEventPublisher eventPublisher)
{    
    public async Task<Guid> Handle(CreateOrderCommand command)
    {
        var Order= new Order(command.ProductName, command.Quantity, command.Price,command.CreatedAt);

        await eventPublisher.PublishOrderCreatedAsync(Order.Id, Order.ProductName, Order.Quantity);

        return Order.Id;
    }
}
