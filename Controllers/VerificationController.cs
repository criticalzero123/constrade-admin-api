
using ConstradeApi_Admin.Model.Response;
using ConstradeApi_Admin.VerificationModel.MValidIdRequest;
using ConstradeApi_Admin.VerificationModel.MValidIdRequest.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstradeApi_Admin.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]

    public class VerificationController : ControllerBase
    {
        private readonly IValidIdRequestRepository _validIdRepo;

        public VerificationController(IValidIdRequestRepository validIdRepo)
        {
            _validIdRepo = validIdRepo;
        }

        [HttpPut("{id}/accept")]
        public async Task<IActionResult> AcceptRequest(int id, int userId)
        {
            try
            {
                var requests = await _validIdRepo.AcceptRequest(id, userId);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, requests));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }

        [HttpPut("{id}/reject")]
        public async Task<IActionResult> RejectRequest(int id, int userId)
        {
            try
            {
                var requests = await _validIdRepo.RejectRequest(id, userId);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, requests));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRequests()
        {
            try
            {
                var requests = await _validIdRepo.GetValidationRequests();

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, requests));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }
    }
}
