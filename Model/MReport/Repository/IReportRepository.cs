using ConstradeApi_Admin.Model.MReport;

namespace ConstradeApi_Admin.Model.MReport.Repository
{
    public interface IReportRepository
    {

        public Task<IEnumerable<ReportResponse>> GetAllReports();
        public Task<bool> CancelReport(int reportId);
    }
}
