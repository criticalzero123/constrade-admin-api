using Microsoft.EntityFrameworkCore;

namespace ConstradeApi_Admin.VerificationEntity
{
    public class AdminVerificationDataContext : DbContext
    {
        public AdminVerificationDataContext(DbContextOptions<AdminVerificationDataContext> option) : base(option)
        {

        }

        public DbSet<ValidIdRequest> ValidIdRequests { get; set; }
        public DbSet<ValidIdentification> ValidIds { get; set; }
        public DbSet<AdminAccounts> AdminAccounts { get; set; }
        public DbSet<ProductPrices> ProductPrices { get; set; }
    }
}
