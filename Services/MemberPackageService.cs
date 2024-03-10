using Membership_Management_UI.Models;

namespace Membership_Management_UI.Services
{
    public class MemberPackageService : IMemberPackageService
    {
        private readonly HttpClient _httpClient;

        public MemberPackageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MemberPackage> Add(MemberPackage entity)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(entity.MemberID.ToString()), "MemberID");
            formData.Add(new StringContent(entity.PackageID.ToString()), "PackageID");
            formData.Add(new StringContent(entity.Quantity.ToString() ?? ""), "Quantity");
            formData.Add(new StringContent(entity.IsActive.ToString() ?? ""), "IsActive");


            var response = await _httpClient.PostAsync("api/MemberPackage", formData);
            response.EnsureSuccessStatusCode();
            return entity;
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/MemberPackage/{id}");
        }

        public async Task<List<MemberPackage>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<MemberPackage>>("api/MemberPackage"); ;
        }

        public async Task<MemberPackage> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<MemberPackage>($"api/MemberPackage/{id}");
        }

        public async Task<MemberPackage> Update(int id, MemberPackage entity)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(entity.MemberPackageID.ToString()), "MemberPackageID");
            formData.Add(new StringContent(entity.MemberID.ToString()), "MemberID");
            formData.Add(new StringContent(entity.PackageID.ToString()), "PackageID");
            formData.Add(new StringContent(entity.Quantity.ToString() ?? ""), "Quantity");
            formData.Add(new StringContent(entity.IsActive.ToString() ?? ""), "IsActive");


            var response = await _httpClient.PutAsync("api/MemberPackage", formData);
            response.EnsureSuccessStatusCode();
            return entity;
        }
    }
}
