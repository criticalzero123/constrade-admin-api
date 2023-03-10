using ConstradeApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace ConstradeApi_Admin.Data
{
    public class AdminDataContext : DbContext
    {
        public AdminDataContext(DbContextOptions<AdminDataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<UserDeactivate> UserDeactivated { get; set; }  
        public DbSet<Report> Reports { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Community> Community { get; set; }
        public DbSet<CommunityPost> Post { get; set; }
        public DbSet<CommunityPostComment> Comment { get; set; }
        public DbSet<SystemFeedback> SystemFeedback { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<SendMoneyTransaction> WalletTransaction { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<SubscriptionHistory> SubscriptionsHistory{ get; set; }
    }
}
