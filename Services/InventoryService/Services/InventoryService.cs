namespace EventSystem.InventoryService.Services;

internal sealed class InventoryManager
{
    public Task ReduceStock(string productName, int quantity)
    {
        // Simulate stock reduction logic
        Console.WriteLine($"Reducing stock for {productName} by {quantity} units.");
        return Task.CompletedTask;
    }
}
