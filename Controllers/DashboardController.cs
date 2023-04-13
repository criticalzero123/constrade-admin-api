using ConstradeApi_Admin.Model.MProduct.Repository;
using ConstradeApi_Admin.Model.MUser;
using ConstradeApi_Admin.Model.MUser.Repository;
using ConstradeApi_Admin.Model.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstradeApi_Admin.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IProductRepository _productRepo;

        public DashboardController(IUserRepository userRepo, IProductRepository productRepo) 
        {
            _userRepo = userRepo;
            _productRepo = productRepo;
        }

        [HttpGet("count/all")]
        public async Task<IActionResult> GetAllCount()
        {
            try
            {
                var userCount = await _userRepo.TotalUsers();
                var userVerifiedCount = await _userRepo.TotalUserVerified();
                var productCount = await _productRepo.GetTotalProducts();
                var transactionCount = await _productRepo.GetTotalTransactions();
                var productStatistics = await _productRepo.GetProductStatistics();
                var userStatistics = await _userRepo.GetUserStatistics();

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, new  {
                                                                                        UserCount = userCount, 
                                                                                        ProductCount = productCount, 
                                                                                        TransactionCount = transactionCount, 
                                                                                        UserVerifiedCount = userVerifiedCount,
                                                                                        ProductStatistics = productStatistics,
                                                                                        UserStatistics= userStatistics
                                                                                    }));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
