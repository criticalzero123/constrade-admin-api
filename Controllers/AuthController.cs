using ConstradeApi_Admin.Model.Response;
using ConstradeApi_Admin.VerificationModel.MAuth.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstradeApi_Admin.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpGet("login")]
        public async Task<IActionResult> LoginAdmin(string username, string password)
        {
            try
            {
                bool isAllowed = await _authRepo.Login(username,password);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, isAllowed));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAdmin(string username, string password)
        {
            try
            {
                bool registered = await _authRepo.Register(username, password);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, registered));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
