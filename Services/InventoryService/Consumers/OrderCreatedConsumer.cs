using EventSystem.InventoryService.Services;
using MassTransit;
using Shared.Contracts;

namespace EventSystem.InventoryService.Consumers;

internal sealed class OrderCreatedConsumer(InventoryManager inventoryManager) :IConsumer<OrderCreatedEvent>
{
    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        await inventoryManager.ReduceStock(context.Message.ProductName, context.Message.Quantity);
    }
}
