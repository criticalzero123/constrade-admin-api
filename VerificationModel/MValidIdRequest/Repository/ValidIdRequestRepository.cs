using ConstradeApi.Entity;
using ConstradeApi.Services.EntityToModel;
using ConstradeApi.VerificationEntity;
using ConstradeApi.VerificationModel.MValidIdRequest;
using ConstradeApi_Admin.Data;
using ConstradeApi_Admin.VerificationEntity;
using Microsoft.EntityFrameworkCore;

namespace ConstradeApi_Admin.VerificationModel.MValidIdRequest.Repository
{
    public class ValidIdRequestRepository : IValidIdRequestRepository
    {
        private readonly AdminVerificationDataContext _context;
        private readonly AdminDataContext _clientContext;

        public ValidIdRequestRepository(AdminVerificationDataContext context, AdminDataContext clientContext)
        {
            _context = context;
            _clientContext = clientContext;
        }

        public async Task<bool> AcceptRequest(int id, int userId)
        {
            ValidIdRequest? request = await _context.ValidIdRequests.FindAsync(id);
            if (request == null) return false;

            User? user = await _clientContext.Users.FindAsync(userId);
            if (user == null) return false;

            user.UserType = "verified";
            await _clientContext.SaveChangesAsync();

            request.Status = "accepted";
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<GetRequestAdmin>> GetValidationRequests()
        {
            var requests = await _context.ValidIdRequests.Where(_r => _r.Status.Equals("pending")).Select(_r => new GetRequestAdmin
            {
                RequestInfo = _r.ToModel(),
                Exist = _context.ValidIds.Any(_v => _v.ValidIdNumber.Equals(_r.ValidIdNumber) && _v.ValidIdType == _r.ValidationType),
            }).ToListAsync();

            return requests;
        }

        public async Task<bool> RejectRequest(int id, int userId)
        {
            ValidIdRequest? request = await _context.ValidIdRequests.FindAsync(id);
            if (request == null) return false;

            request.Status = "rejected";
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
