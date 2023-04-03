using ConstradeApi_Admin.Model.Response;
using ConstradeApi_Admin.Model.MSubscriptionHistory.Repository;
using ConstradeApi_Admin.Model.MUser;
using ConstradeApi_Admin.Model.MUser.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstradeApi_Admin.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly ISubscriptionHistoryRepository _subRepo;

        public UsersController(IUserRepository userRepo, ISubscriptionHistoryRepository subRepo)
        {
            _userRepo = userRepo;
            _subRepo = subRepo;
        }

        [HttpGet("hello")]
        public IActionResult Index()
        {
            return Ok("HEllo World");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userRepo.GetAllUsers();
                
                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, users));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPut("status")]
        public async Task<IActionResult> ChangeStatus([FromBody] UserStatusModel info)
        {
            try
            {
                bool flag = await _userRepo.ChangeStatusUser(info);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, flag));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPut("{id}/block")]
        public async Task<IActionResult> ChangeStatus(int id, int reportId)
        {
            try
            {
                bool flag = await _userRepo.Block(id,reportId);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, flag));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet("{id}/subscription/history")]
        public async Task<IActionResult> GetSubscriptionHistory(int id)
        {
            try
            {
                var data = await _subRepo.GetSubscriptionHistory(id);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetReviews(int id)
        {
            try
            {
                var reviews = await _userRepo.GetReviews(id);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, reviews));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
