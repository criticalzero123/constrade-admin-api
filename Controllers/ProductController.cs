using ConstradeApi.Model.Response;
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

        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
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
    }
}
