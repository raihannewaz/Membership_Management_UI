using Membership_Management_UI.Models;

namespace Membership_Management_UI.Services
{
    public class PackageService:IPackageService
    {
        private readonly HttpClient _httpClient;

        public PackageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Package> Add(Package entity)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(entity.PackageName ?? ""), "PackageName");
            formData.Add(new StringContent(entity.PackagePrice?.ToString() ?? ""), "PackagePrice");
            formData.Add(new StringContent(entity.PaymentType ?? ""), "PaymentType");
            formData.Add(new StringContent(entity.Duration?.ToString() ?? ""), "Duration");
            formData.Add(new StringContent(entity.IsActive?.ToString() ?? ""), "IsActive");


            var response = await _httpClient.PostAsync("api/Package", formData);
            response.EnsureSuccessStatusCode();

            return entity;
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Package/{id}");
        }

        public async Task<List<Package>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Package>>("api/Package");
        }

        public async Task<Package> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Package>($"api/Package/{id}");
        }

        public async Task<Package> Update(int id, Package entity)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(entity.PackageId.ToString() ?? ""), "PackageId");
            formData.Add(new StringContent(entity.PackageName ?? ""), "PackageName");
            formData.Add(new StringContent(entity.PackagePrice?.ToString() ?? ""), "PackagePrice");
            formData.Add(new StringContent(entity.PaymentType ?? ""), "PaymentType");
            formData.Add(new StringContent(entity.Duration?.ToString() ?? ""), "Duration");
            //formData.Add(new StringContent(entity.IsActive?.ToString() ?? ""), "IsActive");


            var response = await _httpClient.PutAsync($"api/Package/{id}", formData);
            response.EnsureSuccessStatusCode();

            return entity;
        }
    }


}
