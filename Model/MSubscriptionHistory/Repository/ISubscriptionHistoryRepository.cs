using ConstradeApi_Admin.Model.MSubcription;

namespace ConstradeApi_Admin.Model.MSubscriptionHistory.Repository
{
    public interface ISubscriptionHistoryRepository
    {
        Task<SubscriptionHistoryModel> GetSubscriptionHistory(int id);

    }
}
