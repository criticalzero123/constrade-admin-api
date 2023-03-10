using ConstradeApi.Model.Response;
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

        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
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
    }
}
