using Membership_Management_UI.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace Membership_Management_UI.Services
{
    public interface IDocumentService
    {
        
        //Task<Document> GetDocumentByMember(int id);
        Task AddDocument(int memberId, Document document);
        Task UpdateDocument(int memberId, Document document);
        Task<string> GetNidOfMember(int memberId);
        Task<string> GetUtilityOfMember(int memberId);
        //Task DeleteMember(int id);
    }
}
