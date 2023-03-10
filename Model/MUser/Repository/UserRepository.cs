using ConstradeApi.Entity;
using ConstradeApi.Model.MReport;
using ConstradeApi.Model.MUser;
using ConstradeApi.Services.EntityToModel;
using ConstradeApi_Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace ConstradeApi_Admin.Model.MUser.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AdminDataContext _context;

        public UserRepository(AdminDataContext context)
        {
            _context = context;
        }

        public async Task<bool> Block(int id, int reportId)
        {
            User? user = await _context.Users.FindAsync(id);
            Report? report = await _context.Reports.FindAsync(reportId);
            if (user == null || report == null) return false;

            _context.Reports.Remove(report);
            user.UserStatus = "block";

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChangeStatusUser(UserStatusModel info)
        {
            User? user = await _context.Users.FindAsync(info.UserId);

            if (user == null) return false;

            if (info.NewStatus.Equals("deactivate"))
            {
                await _context.UserDeactivated.AddAsync(new UserDeactivate
                {
                    UserId = info.UserId,
                });
            }
           
            user.UserStatus = info.NewStatus;
            await _context.SaveChangesAsync();

            return true;
        }



        public async Task<IEnumerable<UserAndPersonModel>> GetAllUsers()
        {
            IEnumerable<UserAndPersonModel> user = await _context.Users.Select(_u => new UserAndPersonModel
            {
                User = _u.ToModel(),
                Person = _u.Person.ToModel()
            }).ToListAsync();

            return user;
        }
    }
}
