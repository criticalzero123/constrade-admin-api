using ConstradeApi_Admin.Entity;
using ConstradeApi_Admin.Model.MCommunity.MCommunityPost;
using ConstradeApi_Admin.Model.MCommunity.MCommunityPostComment;

namespace ConstradeApi_Admin.Model.MCommunityPost.Repository
{
    public interface ICommunityPostRepository
    {
        public Task<bool> Delete(int id, int reportId);
        public Task<IEnumerable<CommunityPostModel>> GetPosts(int id);
    }
}
