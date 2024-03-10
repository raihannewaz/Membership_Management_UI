using Membership_Management_UI.Models;

namespace Membership_Management_UI.Services
{
    public interface IMemberPackageService
    {
        Task<List<MemberPackage>> GetAll();
        Task<List<MemberPackage>> GetById(int id);
        Task<MemberPackage> Add(MemberPackage entity);
        Task<MemberPackage> Update(int id, MemberPackage entity);
        Task Delete(int id);
    }
}
