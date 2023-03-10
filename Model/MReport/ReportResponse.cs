using ConstradeApi.Model.MReport;
using ConstradeApi.Model.MUser;

namespace ConstradeApi_Admin.Model.MReport
{
    public class ReportResponse
    {
        public ReportModel Report { get; set; }
        public UserAndPersonModel UserInfo { get; set; } 
    }
}
