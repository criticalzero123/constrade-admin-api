using ConstradeApi.Entity;
using ConstradeApi.Model.MTransaction;
using ConstradeApi.Model.MUser;

namespace ConstradeApi_Admin.Model.MProduct
{
    public class UserAndTransactionModel
    {
        public TransactionModel Transaction { get; set; }
        public PersonModel Buyer { get; set; }
        public PersonModel Seller { get; set; }
    }
}
