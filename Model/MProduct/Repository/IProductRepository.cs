using ConstradeApi_Admin.Model.MProduct;
using ConstradeApi_Admin.VerificationModel.MProductPrices;

namespace ConstradeApi_Admin.Model.MProduct.Repository
{
    public interface IProductRepository
    {
        public Task<bool> Delete(int id, int reportId);
        Task<IEnumerable<ProductModel>> GetProducts();
        Task<UserAndTransactionModel> GetTransaction(int id);
        Task<int> GetTotalProducts();
        Task<int> GetTotalTransactions();
        Task<IEnumerable<ProductStatistics>> GetProductStatistics();
        Task<bool> AddProductPrices(ProductPricesModel info);
    }
}
