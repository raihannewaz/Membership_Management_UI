using Membership_Management_UI.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Tewr.Blazor.FileReader;

namespace Membership_Management_UI.Services
{
    public class MemberService:IMemberService
    {

        
        private readonly HttpClient _httpClient;


        public MemberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<Member>> GetAllMembers()
        {
            return await _httpClient.GetFromJsonAsync<List<Member>>("api/Member");
        }


        public async Task<Member> GetMember(int id)
        {
            return await _httpClient.GetFromJsonAsync<Member>($"api/Member/{id}");

        }

        public async Task DeleteMember(int id)
        {
            await _httpClient.DeleteAsync($"api/Member/{id}");
        }




        public async Task<Member> AddMember(Member member)
        {
            
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(member.Name ?? ""), "Name");
            formData.Add(new StringContent(member.Phone?.ToString() ?? ""), "Phone");
            formData.Add(new StringContent(member.PresentAddress ?? ""), "PresentAddress");
            formData.Add(new StringContent(member.PermanentAddress ?? ""), "PermanentAddress");
            formData.Add(new StringContent(member.Dob.ToString() ?? ""), "Dob");
            formData.Add(new StringContent(member.MembershipAmount?.ToString() ?? ""), "MembershipAmount");

            if (member.ImageFile != null)
            {
                using var memoryStream = new MemoryStream();
                await member.ImageFile.OpenReadStream().CopyToAsync(memoryStream);
                formData.Add(new ByteArrayContent(memoryStream.ToArray()), "ImageFile", member.ImageFile.Name);
            }

            var response = await _httpClient.PostAsync("api/Member", formData);
            response.EnsureSuccessStatusCode();

            return member;
        }




        public async Task<Member> UpdateMember(int id, Member member)
        {


            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(member.MemberId.ToString() ?? ""), "MemberId");
            formData.Add(new StringContent(member.Name ?? ""), "Name");
            formData.Add(new StringContent(member.Phone?.ToString() ?? ""), "Phone");
            formData.Add(new StringContent(member.PresentAddress ?? ""), "PresentAddress");
            formData.Add(new StringContent(member.PermanentAddress ?? ""), "PermanentAddress");
            formData.Add(new StringContent(member.Dob.ToString() ?? ""), "Dob");
            formData.Add(new StringContent(member.MembershipAmount?.ToString() ?? ""), "MembershipAmount");
            formData.Add(new StringContent(member.IsActive?.ToString() ?? ""), "IsActive");




            if (member.ImageFile != null)
            {
                using var memoryStream = new MemoryStream();
                await member.ImageFile.OpenReadStream().CopyToAsync(memoryStream);
                formData.Add(new ByteArrayContent(memoryStream.ToArray()), "ImageFile", member.ImageFile.Name);
            }

            var response = await _httpClient.PutAsync($"api/Member/{id}", formData);
            response.EnsureSuccessStatusCode();

            return member;


        }

    }
}
