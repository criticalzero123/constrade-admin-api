using ConstradeApi_Admin.Model.MCommunity.MCommunityPostComment;

namespace ConstradeApi_Admin.Model.MCommunityPostComment.Repository
{
    public interface ICommunityPostCommentRepository
    {
        public Task<bool> Delete(int id, int reportId);
        public Task<IEnumerable<CommunityPostCommentModel>> GetComments(int id);

    }
}
