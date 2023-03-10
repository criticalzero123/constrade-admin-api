using ConstradeApi.Model.MSystemFeedback;

namespace ConstradeApi_Admin.Model.MSystemFeedback.Repository
{
    public interface ISystemFeedbackRepository
    {
        Task<IEnumerable<SystemFeedbackModel>> GetFeedbacks();
        Task<IEnumerable<SystemFeedbackModel>> GetBugs();
        Task<bool> FixBug(int id);
        Task<bool> DoneFeedback(int id);
    }
}
