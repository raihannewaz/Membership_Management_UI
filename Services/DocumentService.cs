using Membership_Management_UI.Models;
using Microsoft.AspNetCore.Components.Forms;
using System;


namespace Membership_Management_UI.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly HttpClient _httpClient;


        public DocumentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task AddDocument(int memberId, Document document)
        {
            using var formData = new MultipartFormDataContent();

            if (document.NidFile != null)
            {

                formData.Add(new StreamContent(document.NidFile.OpenReadStream()), "nidFile", document.NidFile.Name);
                
            }

            if (document.UtilityFile != null)
            {
                formData.Add(new StreamContent(document.UtilityFile.OpenReadStream()), "utilityFile", document.UtilityFile.Name);
            }


            var response = await _httpClient.PutAsync($"api/Document/{memberId}", formData);
            response.EnsureSuccessStatusCode();
        }


        public async Task  UpdateDocument(int memberId, Document document)
        {
            var formData = new MultipartFormDataContent();

            if (document.NidFile != null)
            {
                formData.Add(new StreamContent(document.NidFile.OpenReadStream()), "nidFile", document.NidFile.Name);
            }

            if (document.UtilityFile != null)
            {
                formData.Add(new StreamContent(document.UtilityFile.OpenReadStream()), "utilityFile", document.UtilityFile.Name);
            }

             var response = await _httpClient.PutAsync($"api/Document/{memberId}", formData);
            response.EnsureSuccessStatusCode();

        }


        public async Task<string> GetNidOfMember(int memberId)
        {
            var response = await _httpClient.GetAsync($"getNid/{memberId}");
            response.EnsureSuccessStatusCode();
            string nid = await response.Content.ReadAsStringAsync();
            return nid;
        }


        public async Task<string> GetUtilityOfMember(int memberId)
        {
            var response = await _httpClient.GetAsync($"getUtility/{memberId}");
            response.EnsureSuccessStatusCode();
            string utlity = await response.Content.ReadAsStringAsync();
            return utlity;
        }
    }
}
