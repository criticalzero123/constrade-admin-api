using ConstradeApi_Admin.Services.Password;
using ConstradeApi_Admin.VerificationEntity;
using Microsoft.EntityFrameworkCore;

namespace ConstradeApi_Admin.VerificationModel.MAuth.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AdminVerificationDataContext _context;

        public AuthRepository(AdminVerificationDataContext context)
        {
            _context = context;
        }
        public async Task<bool> Login(string username, string password)
        {
            AdminAccounts? account = await _context.AdminAccounts.Where(account => account.UserName == username && PasswordHelper.Hash(password) == account.Password)
                                                                 .FirstOrDefaultAsync();

            return account != null;

        }

        public async Task<bool> Register(string username, string password, string key)
        {
            if(key != "constrade123") return false;
            AdminAccounts account = new AdminAccounts()
            {
                UserName = username,
                Password = PasswordHelper.Hash(password)
            };

            await _context.AdminAccounts.AddAsync(account);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
