using ConstradeApi_Admin.Entity;
using ConstradeApi_Admin.Services.EntityToModel;
using ConstradeApi_Admin.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ConstradeApi_Admin.Model.MBoostProduct.Repository
{
    public class BoostProductRepository : IBoostProductRepository
    {
        private readonly AdminDataContext _context;

        public BoostProductRepository(AdminDataContext context)
        {
            _context = context;
        }

        public async Task<bool> CancelBoost(int id)
        {
            BoostProduct? boostProduct = await _context.BoostedProduct.FindAsync(id);

            if (boostProduct == null) return false;

            if(DateTime.Now > boostProduct.DateTimeExpired)
            {
                boostProduct.Status = "expired";
                return false;
            }

            boostProduct.Status = "cancelled";
            boostProduct.DateTimeExpired= DateTime.Now;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<BoostProduct>> GetAll()
        {
            IEnumerable<BoostProduct> boosted = await _context.BoostedProduct.Where(_b => _b.Status == "active").ToListAsync();

            return boosted;
        }
    }
}
