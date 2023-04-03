using ConstradeApi_Admin.Model.MCommunity;

namespace ConstradeApi_Admin.Model.MCommunity.Repository
{
    public interface ICommunityRepository
    {
        public Task<bool> Delete(int id, int reportId);
        Task<IEnumerable<CommunityModel>> GetAllCommunity();
    }
}
