namespace ConstradeApi_Admin.Model.MNotification.Repository
{
    public interface INotificationRepository
    {
        public Task<bool> SendAlert(int id);
    }
}
