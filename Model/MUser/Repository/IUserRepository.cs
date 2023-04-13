namespace ConstradeApi_Admin.Model.MUser.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserAndPersonModel>> GetAllUsers();
        Task<bool> ChangeStatusUser(UserStatusModel info);
        Task<bool> Block(int id, int reportId);
        Task<IEnumerable<ReviewAndPersonModel>> GetReviews(int uid);
        Task<int> TotalUsers();
        Task<int> TotalUserVerified();
        Task<IEnumerable<UserStatistics>> GetUserStatistics();
    }
}
