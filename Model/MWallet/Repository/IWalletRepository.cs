using ConstradeApi.Model.MWallet;

namespace ConstradeApi_Admin.Model.MWallet.Repository
{
    public interface IWalletRepository
    { 
        Task<IEnumerable<WalletModel>> GetWallet();
        Task<IEnumerable<SendMoneyTransactionModel>> GetTransaction(int id);
    }
}
