namespace EventSystem.OrderService.Application.Interfaces;

public interface IEventPublisher
{
    Task PublishOrderCreatedAsyn(Guid orderId, string product, int quantity);
}
