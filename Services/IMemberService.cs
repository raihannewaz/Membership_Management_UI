using Membership_Management_UI.Models;

namespace Membership_Management_UI.Services
{
    public interface IMemberService
    {
        Task<List<Member>> GetAllMembers();
        Task<Member> GetMember(int id);
        Task<Member> AddMember(Member member);
        Task<Member> UpdateMember(int id, Member member);
        Task DeleteMember(int id);
    }
}
