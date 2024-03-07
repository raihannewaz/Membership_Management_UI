using Membership_Management_UI.Models;

namespace Membership_Management_UI.Services
{
    public interface IFeeCollectionService
    {
        Task<FeeCollection> PostFeeCollectionAsync(FeeCollection feeCollection);
        Task<List<FeeCollection>> GetCollectedFee();
        Task<List<FeeCollection>> GetCollectedFeeById(int id);
    }
}
