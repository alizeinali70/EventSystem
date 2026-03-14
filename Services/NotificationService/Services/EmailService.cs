namespace EventSystem.NotificationService.Services
{
    internal sealed class EmailService
    {
        public static Task SendOrderEmail(Guid orderId)
        {
            Console.WriteLine($"Sending email for order {orderId}");

            return Task.CompletedTask;
        }
    }
}
