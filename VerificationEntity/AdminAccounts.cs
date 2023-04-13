using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstradeApi_Admin.VerificationEntity
{
    [Table("admin_accounts")]
    public class AdminAccounts
    {
        [Key]
        public int AdminAccountId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
