using ConstradeApi.Entity;

namespace ConstradeApi_Admin.Model.MBoostProduct.Repository
{
    public interface IBoostProductRepository
    {
        Task<IEnumerable<BoostProduct>> GetAll();
        Task<bool> CancelBoost(int id);
    }
}
