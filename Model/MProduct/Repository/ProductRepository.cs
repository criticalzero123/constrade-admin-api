using ConstradeApi_Admin.Entity;
using ConstradeApi_Admin.Model.MProduct;
using ConstradeApi_Admin.Services.EntityToModel;
using ConstradeApi_Admin.Data;
using Microsoft.EntityFrameworkCore;
using ConstradeApi_Admin.VerificationEntity;
using ConstradeApi_Admin.VerificationModel.MProductPrices;

namespace ConstradeApi_Admin.Model.MProduct.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdminDataContext _context;
        private readonly AdminVerificationDataContext _verificationContext;

        public ProductRepository(AdminDataContext context, AdminVerificationDataContext verificationContext)
        {
            _context = context;
            _verificationContext = verificationContext;
        }

        public async Task<bool> AddProductPrices(ProductPricesModel info)
        {
            ProductPrices price = new ProductPrices()
            {
                AddedBy = info.AddedBy,
                Name= info.Name,
                ShopName = info.ShopName,
                Value = info.Value,
                Platform = info.Platform,
                Genre= info.Genre,
                OriginUrl = info.OriginUrl,
                ReleaseDate = info.ReleaseDate,
            };

            await _verificationContext.ProductPrices.AddAsync(price);
            await _verificationContext.SaveChangesAsync();
            return true;
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

        public async Task<IEnumerable<ProductStatistics>> GetProductStatistics()
        {
            return await _context.Products.Select(p => new ProductStatistics
            {
                ProductStatus = p.ProductStatus,
                Date = p.DateCreated
            }).ToListAsync();
        }

        public async Task<int> GetTotalProducts()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<int> GetTotalTransactions()
        {
            return await _context.Transactions.CountAsync();
        }

        public async Task<UserAndTransactionModel> GetTransaction(int id)
        {
            Transaction transaction = await _context.Transactions.Include(_t => _t.Seller.Person).Include(_t => _t.Buyer.Person).Where(_t => _t.ProductId == id).FirstAsync();

            return new UserAndTransactionModel
            {
                Transaction = transaction.ToModel(),
                Buyer = transaction.Buyer.Person.ToModel(),
                Seller = transaction.Seller.Person.ToModel(),
            };
        }
    }
}
