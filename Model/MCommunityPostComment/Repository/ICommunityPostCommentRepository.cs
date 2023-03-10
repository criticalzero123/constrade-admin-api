namespace ConstradeApi_Admin.Model.MCommunityPostComment.Repository
{
    public interface ICommunityPostCommentRepository
    {
        public Task<bool> Delete(int id, int reportId);
    }
}
