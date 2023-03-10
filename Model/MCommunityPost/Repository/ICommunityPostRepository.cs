namespace ConstradeApi_Admin.Model.MCommunityPost.Repository
{
    public interface ICommunityPostRepository
    {
        public Task<bool> Delete(int id, int reportId);
    }
}
