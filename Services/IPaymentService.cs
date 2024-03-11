using Membership_Management_UI.Models;

namespace Membership_Management_UI.Services
{
    public interface IPaymentService
    {
        Task<Payment> Add(Payment payment);
        Task<List<Payment>> GetAll();
        Task<List<Payment>> GetByMember(int id);

        Task<List<(string Name, string PackageName, DateTime NextPaymentDate)>> GetNextPaymentDates();
        Task<DateTime?> GetNextPaymentDate(int memberId);
    }
}
