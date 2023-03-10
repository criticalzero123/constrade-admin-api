using ConstradeApi.Model.MSubcription;

namespace ConstradeApi_Admin.Model.MSubscriptionHistory.Repository
{
    public interface ISubscriptionHistoryRepository
    {
        Task<SubscriptionHistoryModel> GetSubscriptionHistory(int id);

    }
}
