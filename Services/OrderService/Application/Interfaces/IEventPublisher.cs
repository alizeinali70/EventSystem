namespace EventSystem.OrderService.Application.Interfaces;

internal interface IEventPublisher
{
    Task PublishOrderCreatedAsync(Guid orderId, string product, int quantity);
}
