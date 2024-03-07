using Membership_Management_UI.Models;

namespace Membership_Management_UI.Services
{
    public class FeeCollectionService : IFeeCollectionService
    {
        private readonly HttpClient _httpClient;

        public FeeCollectionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FeeCollection>> GetCollectedFee()
        {
            return await _httpClient.GetFromJsonAsync<List<FeeCollection>>("api/FeeCollection");

        }

        public async Task<List<FeeCollection>> GetCollectedFeeById(int id)
        {
            return await _httpClient.GetFromJsonAsync<List<FeeCollection>>($"api/FeeCollection/{id}");
        }

        public async Task<FeeCollection> PostFeeCollectionAsync(FeeCollection feeCollection)
        {
            try
            {
                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(feeCollection.CollectionType ?? ""), "CollectionType");
                formData.Add(new StringContent(feeCollection.Amount.ToString() ?? ""), "Amount");
                formData.Add(new StringContent(feeCollection.MemberId.ToString() ?? ""), "MemberId");

                var response = await _httpClient.PostAsync("api/FeeCollection", formData);
                response.EnsureSuccessStatusCode();
                return feeCollection;
            }
            catch (Exception)
            {

                throw new ArgumentException("field may not valied!");
            }
        }
    }

}
