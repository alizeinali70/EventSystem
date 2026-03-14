using EventSystem.NotificationService.Services;
using MassTransit;
using Shared.Contracts;

namespace EventSystem.NotificationService.Consumers;

internal sealed class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
{
    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        await EmailService.SendOrderEmail(context.Message.OrderId);
    }
}
