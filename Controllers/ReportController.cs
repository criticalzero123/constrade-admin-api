using ConstradeApi.Model.Response;
using ConstradeApi_Admin.Model.MReport.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstradeApi_Admin.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepo;

        public ReportController(IReportRepository reportRepo)
        {
            _reportRepo = reportRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReport()
        {
            try
            {
                var reports = await _reportRepo.GetAllReports();

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, reports));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelReportById(int id)
        {
            try
            {
                var reports = await _reportRepo.CancelReport(id);

                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, reports));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
