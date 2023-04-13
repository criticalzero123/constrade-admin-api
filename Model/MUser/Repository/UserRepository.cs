using ConstradeApi_Admin.Entity;
using ConstradeApi_Admin.Model.MUser;
using ConstradeApi_Admin.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ConstradeApi_Admin.Services.EntityToModel;

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

            foreach (var user in users)
            {
                IEnumerable<Transaction> transactions = await _context.Transactions.Where(_t => _t.SellerUserId == user.UserId && _t.IsReviewed).ToListAsync();
                decimal rates = 0;

                if (transactions.Any())
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

        public async Task<IEnumerable<ReviewAndPersonModel>> GetReviews(int uid)
        {
            IEnumerable<Transaction> transaction = await _context.Transactions.Include(_t => _t.Buyer.Person).Include(_t => _t.Seller.Person).Where(_u => _u.SellerUserId == uid).ToListAsync();

            IEnumerable<ReviewAndPersonModel> reviews = _context.Reviews.ToList().Join(transaction,
                                                                                       _r => _r.TransactionRefId,
                                                                                       _t => _t.TransactionId,
                                                                                       (_r, _t) => new { _r, _t }
                                                                                       )
                                                                                 .Select(_result => new ReviewAndPersonModel
                                                                                 {
                                                                                     Person = _result._t.Buyer.Person.ToModel(),
                                                                                     Review = _result._r.ToModel(),
                                                                                 });
            return reviews;
        }

        public async Task<IEnumerable<UserStatistics>> GetUserStatistics()
        {
            return await _context.Users.Select(u => new UserStatistics
            {
                UserType = u.UserType,
                Date = u.DateCreated
            }).ToListAsync();
        }

        public async Task<int> TotalUsers()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<int> TotalUserVerified()
        {
            return await _context.Users.Where(u => u.UserType != "semi-verified").CountAsync();
        }
    }
}
