using Radzen;

namespace PasswordStorageApp.BlazorClient.Services
{
    public class RadzenToastManager : IToastService
    {
        private readonly NotificationService _notificationService;

        public RadzenToastManager(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public void Success(string message)
        {
            _notificationService.Notify(NotificationSeverity.Success,message);
        }

        public void Success(string message, string title)
        {
            _notificationService.Notify(NotificationSeverity.Success, title, message);
        }

        public void Warning(string message)
        {
            _notificationService.Notify(NotificationSeverity.Warning, message);
        }

        public void Warning(string message, string title)
        {
            _notificationService.Notify(NotificationSeverity.Warning, title, message);
        }

        public void Info(string message)
        {
            _notificationService.Notify(NotificationSeverity.Info, message);
        }

        public void Info(string message, string title)
        {
            _notificationService.Notify(NotificationSeverity.Info, title, message);
        }

        public void Error(string message)
        {
            _notificationService.Notify(NotificationSeverity.Error, message);
        }

        public void Error(string message, string title)
        {
            _notificationService.Notify(NotificationSeverity.Error, title, message);
        }
    }
}
