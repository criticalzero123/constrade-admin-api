using ConstradeApi.Entity;
using ConstradeApi.Model.MCommunity.MCommunityPost;
using ConstradeApi.Model.MCommunity.MCommunityPostComment;
using ConstradeApi.Services.EntityToModel;
using ConstradeApi_Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace ConstradeApi_Admin.Model.MCommunityPost.Repository
{
    public class CommunityPostRepository : ICommunityPostRepository
    {
        private readonly AdminDataContext _context;

        public CommunityPostRepository(AdminDataContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id, int reportId)
        {
            CommunityPost? post = await _context.Post.FindAsync(id);
            Report? report = await _context.Reports.FindAsync(reportId);

            if (report == null) return false;
            if(post != null) _context.Post.Remove(post);

            _context.Reports.Remove(report);
            _context.SaveChanges();

            return true;
        }

   

        public async Task<IEnumerable<CommunityPostModel>> GetPosts(int id)
        {
            IEnumerable<CommunityPostModel> posts = await _context.Post.Where(_p => _p.CommunityId == id)
                                                                       .Select(_p => _p.ToModel())
                                                                       .ToListAsync();

            return posts;
        }
    }
}
