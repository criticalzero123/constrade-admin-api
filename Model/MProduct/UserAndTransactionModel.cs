using ConstradeApi_Admin.Entity;
using ConstradeApi_Admin.Model.MTransaction;
using ConstradeApi_Admin.Model.MUser;

namespace ConstradeApi_Admin.Model.MProduct
{
    public class UserAndTransactionModel
    {
        public TransactionModel Transaction { get; set; }
        public PersonModel Buyer { get; set; }
        public PersonModel Seller { get; set; }
    }
}
