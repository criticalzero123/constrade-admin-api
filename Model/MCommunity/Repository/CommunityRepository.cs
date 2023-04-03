
using ConstradeApi_Admin.Entity;
using ConstradeApi_Admin.Model.MCommunity;
using ConstradeApi_Admin.Services.EntityToModel;
using ConstradeApi_Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace ConstradeApi_Admin.Model.MCommunity.Repository
{
    public class CommunityRepository : ICommunityRepository
    {
        private readonly AdminDataContext _context;

        public CommunityRepository(AdminDataContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id, int reportId)
        {
            Community? community = await _context.Community.FindAsync(id);
            Report? report = await _context.Reports.FindAsync(reportId);
            if (report == null) return false;

            if (community != null) _context.Community.Remove(community);

            _context.Reports.Remove(report);
            _context.SaveChanges();

            return true;
        }

        public async Task<IEnumerable<CommunityModel>> GetAllCommunity()
        {
            IEnumerable<CommunityModel> model = await _context.Community.Select(_c => _c.ToModel()).ToListAsync();


              return model;
        }
    }
}
