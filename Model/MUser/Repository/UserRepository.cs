using ConstradeApi.Entity;
using ConstradeApi.Model.MUser;
using ConstradeApi_Admin.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ConstradeApi.Services.EntityToModel;

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

            IEnumerable<User> users = _context.Users.Include(_u => _u.Person).ToList();
            List<UserAndPersonModel> u = new List<UserAndPersonModel>();

            foreach(var user in users)
            {
                IEnumerable<Transaction> transactions = await _context.Transactions.Where(_t => _t.SellerUserId == user.UserId && _t.IsReviewed).ToListAsync();
                decimal rates = 0;

                if(transactions.Any())
                {
                    rates = _context.Reviews.ToList().Join(transactions,
                                                                   _r => _r.TransactionRefId,
                                                                   _t => _t.TransactionId,
                                                                   (_r, _t) => new { _r, _t }
                                                                   )
                                                                .Select(result => Convert.ToDecimal(result._r.Rate)).ToList().Average();
                }

                
                u.Add(new UserAndPersonModel
                {
                    Person = user.Person.ToModel(),
                    User = user.ToModel(),
                    Rate = rates
                });
            }
            

            return u;
        }
    }
}
