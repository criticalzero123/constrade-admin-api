using ConstradeApi_Admin.Services.EntityToModel;
using ConstradeApi_Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace ConstradeApi_Admin.Model.MWallet.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly AdminDataContext _context;

        public WalletRepository(AdminDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SendMoneyTransactionModel>> GetTransaction(int id)
        {
            IEnumerable<SendMoneyTransactionModel> result = await _context.WalletTransaction.Where(_w => _w.SenderWalletId == id ||
                                                                                                         _w.ReceiverWalletId== id)
                                                                                            .Select(_w => _w.ToModel()).ToListAsync();


            return result;
        }

        public async Task<IEnumerable<WalletModel>> GetWallet()
        {
            IEnumerable<WalletModel> wallet = await _context.Wallet.Select(_p => _p.ToModel())
                                                                   .ToListAsync();

            return wallet;
        }
    }
}
