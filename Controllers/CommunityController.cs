using ConstradeApi_Admin.Model.Response;
using ConstradeApi_Admin.Model.MCommunity.Repository;
using ConstradeApi_Admin.Model.MCommunityPost.Repository;
using ConstradeApi_Admin.Model.MCommunityPostComment.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstradeApi_Admin.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class CommunityController : ControllerBase
    {
        private readonly ICommunityRepository _communityRepo;
        private readonly ICommunityPostRepository _postRepo;
        private readonly ICommunityPostCommentRepository _commentRepo;

        public CommunityController(ICommunityRepository communityRepo, ICommunityPostRepository postRepo, ICommunityPostCommentRepository commentRepo)
        {
            _communityRepo = communityRepo;
            _postRepo = postRepo;
            _commentRepo = commentRepo;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunity(int id, int reportId)
        {
            try
            {
                bool flag = await _communityRepo.Delete(id, reportId);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, flag));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete("post/{id}")]
        public async Task<IActionResult> DeleteCommunityPost(int id, int reportId)
        {
            try
            {
                bool flag = await _postRepo.Delete(id, reportId);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, flag));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete("post/comment/{id}")]
        public async Task<IActionResult> DeleteCommunityComment(int id, int reportId)
        {
            try
            {
                bool flag = await _commentRepo.Delete(id, reportId);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, flag));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCommunities()
        {
            try
            {
                var communities = await _communityRepo.GetAllCommunity();
                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, communities));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet("post/{id}")]
        public async Task<IActionResult> GetPosts(int id)
        {
            try
            {
                var posts = await _postRepo.GetPosts(id);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, posts));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet("post/comment/{id}")]
        public async Task<IActionResult> GetComments(int id)
        {
            try
            {
                var comments = await _commentRepo.GetComments(id);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, comments));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
