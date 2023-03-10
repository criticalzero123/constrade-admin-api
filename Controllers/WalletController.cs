using ConstradeApi.Model.Response;
using ConstradeApi_Admin.Model.MWallet.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstradeApi_Admin.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletRepository walletRepo;

        public WalletController(IWalletRepository _walletRepo)
        {
            walletRepo = _walletRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWallet()
        {
            try
            {
                var products = await walletRepo.GetWallet();

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, products));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            try
            {
                var transactions = await walletRepo.GetTransaction(id);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, transactions));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
