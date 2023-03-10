using ConstradeApi.Entity;
using ConstradeApi.Model.MProduct;
using ConstradeApi.Services.EntityToModel;
using ConstradeApi_Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace ConstradeApi_Admin.Model.MProduct.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdminDataContext _context;

        public ProductRepository(AdminDataContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id, int reportId)
        {
            Product? _product = await _context.Products.FindAsync(id);
            Report? report = await _context.Reports.FindAsync(reportId);

            if ( report == null) return false;
            if(_product != null) _context.Products.Remove(_product);

            _context.Reports.Remove(report);
           
            _context.SaveChanges();

            return true;
        }

        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            IEnumerable<ProductModel> products = await _context.Products.Select(_p => _p.ToModel()).ToListAsync();

            return products;
        }
    }
}
