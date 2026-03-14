namespace EventSystem.OrderService.Application.Interfaces;

internal interface IEventPublisher
{
    Task PublishOrderCreatedAsyn(Guid orderId, string product, int quantity);
}
