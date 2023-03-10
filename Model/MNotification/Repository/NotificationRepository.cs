using ConstradeApi.Entity;
using ConstradeApi_Admin.Data;

namespace ConstradeApi_Admin.Model.MNotification.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AdminDataContext _context;

        public NotificationRepository(AdminDataContext context)
        {
             _context = context;
        }

        public async Task<bool> SendAlert(int id)
        {
            UserNotification notification = new UserNotification()
            {
                UserId = id,
                ToId = id,
                ImageUrl = "https://lh3.googleusercontent.com/muIbR01b3g-tYFZKwBtMfGs2GAR5S2mA2rfDwlep35yIqMuRUZfa2__m7HDauSGSMOKYQmVEaeE3H4QOxewXRtHz3FNGAg7um4KanmteLKShUtTxuq4L31yYNGAP3apuZwC-d-TyVA=w2400",
                NotificationType = "alert",
                NotificationMessage= "Your account is being warn. Please refrain being a bad boy.",
                NotificationDate = DateTime.Now,
            };

            await _context.AddAsync(notification);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
