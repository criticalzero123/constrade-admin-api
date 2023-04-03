using ConstradeApi_Admin.Model.Response;
using ConstradeApi_Admin.Model.MNotification.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstradeApi_Admin.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository notifRepo;

        public NotificationController(INotificationRepository _repo)
        {
            notifRepo = _repo;
        }

        [HttpPost("alert/{id}")]
        public async Task<IActionResult> AlertAccount(int id)
        {
            try
            {
                bool flag = await notifRepo.SendAlert(id);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, flag));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
