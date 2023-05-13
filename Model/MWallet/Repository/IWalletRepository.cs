
using ConstradeApi_Admin.Entity;

namespace ConstradeApi_Admin.Model.MWallet.Repository
{
    public interface IWalletRepository
    { 
        Task<IEnumerable<WalletModel>> GetWallet();
        Task<IEnumerable<SendMoneyTransactionModel>> GetTransaction(int id);
        Task<IEnumerable<OtherTransaction>> GetOtherTransactionWalletPartial(int walletId);
    }
}
