using ConstradeApi_Admin.Entity;
using ConstradeApi_Admin.Model.MSystemFeedback;
using ConstradeApi_Admin.Services.EntityToModel;
using ConstradeApi_Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace ConstradeApi_Admin.Model.MSystemFeedback.Repository
{
    public class SystemFeedbackRepository : ISystemFeedbackRepository
    {
        private readonly AdminDataContext _context;

        public SystemFeedbackRepository(AdminDataContext context)
        {
            _context = context;
        }

        public async Task<bool> DoneFeedback(int id)
        {
            SystemFeedback? feedback = await _context.SystemFeedback.FindAsync(id);

            if (feedback == null) return false;

            feedback.Status = "done";
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<bool> FixBug(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SystemFeedbackModel>> GetBugs()
        {
            IEnumerable<SystemFeedbackModel> result = await _context.SystemFeedback.Where(_f => _f.ReportType.Equals("bug"))
                                                                                   .Select(_p => _p.ToModel())
                                                                                   .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<SystemFeedbackModel>> GetFeedbacks()
        {
            IEnumerable<SystemFeedbackModel> result = await _context.SystemFeedback.Where(_f => _f.ReportType.Equals("suggestion"))
                                                                                   .Select(_p => _p.ToModel())
                                                                                   .ToListAsync();

            return result;
        }
    }
}
