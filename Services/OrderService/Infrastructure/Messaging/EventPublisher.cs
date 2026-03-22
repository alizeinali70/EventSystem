using EventSystem.OrderService.Application.Interfaces;
using MassTransit;
using Shared.Contracts;

namespace EventSystem.OrderService.Infrastructure.Messaging
{
    internal sealed class EventPublisher(IPublishEndpoint publishEndpoint) : IEventPublisher
    {        
        public async Task PublishOrderCreatedAsync(Guid orderId, string product, int quantity)
        {
           await publishEndpoint.Publish(new OrderCreatedEvent(
                OrderId: orderId,
                ProductName: product,
                Quantity: quantity,
                CreatedAt: DateTime.UtcNow
            ));

        }
    }
}
