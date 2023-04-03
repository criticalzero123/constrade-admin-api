using ConstradeApi_Admin.Entity;
using ConstradeApi_Admin.VerificationModel.MValidIdRequest;

namespace ConstradeApi_Admin.VerificationModel.MValidIdRequest.Repository
{
    public interface IValidIdRequestRepository
    {
        Task<IEnumerable<GetRequestAdmin>> GetValidationRequests();
        Task<bool> AcceptRequest(int id,int userId);
        Task<bool> RejectRequest(int id,int userId);
    }
}
