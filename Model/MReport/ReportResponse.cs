using ConstradeApi_Admin.Model.MReport;
using ConstradeApi_Admin.Model.MUser;

namespace ConstradeApi_Admin.Model.MReport
{
    public class ReportResponse
    {
        public ReportModel Report { get; set; }
        public UserAndPersonModel UserInfo { get; set; } 
    }
}
