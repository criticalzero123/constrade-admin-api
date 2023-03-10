using ConstradeApi.Entity;
using ConstradeApi.Model.MReport;
using ConstradeApi.Model.MUser;
using ConstradeApi.Services.EntityToModel;
using ConstradeApi_Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace ConstradeApi_Admin.Model.MReport.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly AdminDataContext _context;

        public ReportRepository(AdminDataContext context)
        {
              _context = context;
        }

        public async Task<bool> CancelReport(int reportId)
        {
            Report? report = await _context.Reports.FindAsync(reportId);

            if (report == null) return false;

            _context.Reports.Remove(report);
            _context.SaveChanges();

            return true;
        }

        public async Task<IEnumerable<ReportResponse>> GetAllReports()
        {
            IEnumerable<ReportResponse> result = await _context.Reports.Include(_u => _u.User)
                                                                        .Include(_u => _u.User.Person)
                                                                        .Select(_r => new ReportResponse
                                                                        {
                                                                            Report = _r.ToModel(),
                                                                            UserInfo = new UserAndPersonModel
                                                                            {
                                                                                User = _r.User.ToModel(),
                                                                                Person = _r.User.Person.ToModel()
                                                                            }
                                                                        }).ToListAsync();

            return result;
        }
    }
}
