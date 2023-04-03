using ConstradeApi_Admin.Model.MSubcription;
using ConstradeApi_Admin.Services.EntityToModel;
using ConstradeApi_Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace ConstradeApi_Admin.Model.MSubscriptionHistory.Repository
{
    public class SubscriptionHistoryRepository : ISubscriptionHistoryRepository
    {
        private readonly AdminDataContext _context;

        public SubscriptionHistoryRepository(AdminDataContext context)
        {
            _context = context;
        }
        public async Task<SubscriptionHistoryModel> GetSubscriptionHistory(int id)
        {
            SubscriptionHistoryModel model = await _context.SubscriptionsHistory.Where(_s => _s.Subscription.UserId == id).Select(_s => _s.ToModel()).FirstAsync();

            return model;
        }
    }
}
