using EventSystem.OrderService.Application.Commands;
using EventSystem.OrderService.Application.Interfaces;
using EventSystem.OrderService.Domain.Entities;

namespace EventSystem.OrderService.Application.Handler;

public class CreateOrderHandler
{
    private readonly IEventPublisher _eventPublisher;

    public CreateOrderHandler(IEventPublisher eventPublisher)
    {
        _eventPublisher = eventPublisher;
    }

    public async Task Handle(CreateOrderCommand command)
    {
        var Order= new Order(command.ProductName, command.Quantity);

        await _eventPublisher.PublishAsync(new OrderCreatedEvent(Order.Id, Order.ProductName, Order.Quantity));

        return Order.Id;
    }
}
