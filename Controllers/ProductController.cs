using ConstradeApi_Admin.Model.Response;
using ConstradeApi_Admin.Model.MBoostProduct.Repository;
using ConstradeApi_Admin.Model.MProduct.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstradeApi_Admin.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IBoostProductRepository _boost;

        public ProductController(IProductRepository productRepo, IBoostProductRepository boost)
        {
            _productRepo = productRepo;
            _boost = boost;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id, int reportId)
        {
            try
            {
                bool flag = await _productRepo.Delete(id, reportId);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, flag));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                var products = await _productRepo.GetProducts();

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, products));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet("{id}/transaction")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            try
            {
                var transaction = await _productRepo.GetTransaction(id);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, transaction));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet("boosted")]
        public async Task<IActionResult> GetBoostedProducts()
        {
            try
            {
                var products = await _boost.GetAll();

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, products));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPut("boosted/{id}/cancel")]
        public async Task<IActionResult> CancelBoost(int id)
        {
            try
            {
                var flag = await _boost.CancelBoost(id);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, flag));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
