using ConstradeApi.Model.Response;
using ConstradeApi_Admin.Model.MSystemFeedback.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstradeApi_Admin.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private readonly ISystemFeedbackRepository _systemRepo;

        public SystemController(ISystemFeedbackRepository systemRepo)
        {
            _systemRepo = systemRepo;
        }

        [HttpGet("bugs")]
        public async Task<IActionResult> GetBug()
        {
            try
            {
                var bugs = await _systemRepo.GetBugs();

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, bugs));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }


        [HttpGet("feedbacks")]
        public async Task<IActionResult> GetFeedback()
        {
            try
            {
                var feedbacks = await _systemRepo.GetFeedbacks();

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, feedbacks));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> MarkAsDone(int id)
        {
            try
            {
                bool flag = await _systemRepo.DoneFeedback(id);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, flag));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
