using ConstradeApi_Admin.Entity;
using ConstradeApi_Admin.Model.MCommunity.MCommunityPostComment;
using ConstradeApi_Admin.Services.EntityToModel;
using ConstradeApi_Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace ConstradeApi_Admin.Model.MCommunityPostComment.Repository
{
    public class CommunityPostCommentRepository : ICommunityPostCommentRepository
    {
        private readonly AdminDataContext _context;

        public CommunityPostCommentRepository(AdminDataContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id, int reportId)
        {
            CommunityPostComment? comment = await _context.Comment.FindAsync(id);
            Report? report = await _context.Reports.FindAsync(reportId);

            if ( report == null) return false;
            if(comment != null) _context.Comment.Remove(comment);

            _context.Reports.Remove(report);
            _context.SaveChanges();

            return true;
        }

        public async Task<IEnumerable<CommunityPostCommentModel>> GetComments(int id)
        {
            IEnumerable<CommunityPostCommentModel> comments = await _context.Comment.Where(_c => _c.CommunityPostId == id)
                                                                                    .Select(_c => _c.ToModel())
                                                                                    .ToListAsync();

            return comments;
        }
    }
}
