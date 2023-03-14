using ConstradeApi.Model.MProduct;

namespace ConstradeApi_Admin.Model.MProduct.Repository
{
    public interface IProductRepository
    {
        public Task<bool> Delete(int id, int reportId);
        Task<IEnumerable<ProductModel>> GetProducts();
        Task<UserAndTransactionModel> GetTransaction(int id);
    }
}
