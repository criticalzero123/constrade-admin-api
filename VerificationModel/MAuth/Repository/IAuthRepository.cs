namespace ConstradeApi_Admin.VerificationModel.MAuth.Repository
{
    public interface IAuthRepository
    {
        Task<bool> Login(string username, string password);
        Task<bool> Register(string username, string password);
    }
}
