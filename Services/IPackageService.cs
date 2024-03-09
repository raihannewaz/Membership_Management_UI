using Membership_Management_UI.Models;

namespace Membership_Management_UI.Services
{
    public interface IPackageService
    {
        Task<List<Package>> GetAll();
        Task<Package> GetById(int id);
        Task<Package> Add(Package entity);
        Task<Package> Update(int id, Package entiy);
        Task Delete(int id);
    }
}
