using ConstradeApi.Model.MReport;
using ConstradeApi.Model.MUser;

namespace ConstradeApi_Admin.Model.MUser.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserAndPersonModel>> GetAllUsers();
        public Task<bool> ChangeStatusUser(UserStatusModel info);
        public Task<bool> Block(int id, int reportId);
    }
}
