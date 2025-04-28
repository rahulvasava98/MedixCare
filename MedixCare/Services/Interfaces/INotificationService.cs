using MedixCare.DTOs;

namespace MedixCare.Services.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDTO>> GetAllNotificationsAsync();
        Task<NotificationDTO> GetNotificationByIdAsync(int id);
        Task CreateNotificationAsync(NotificationDTO notificationDto);
        Task MarkAsReadAsync(int id);
        Task DeleteNotificationAsync(int id);
    }
}
