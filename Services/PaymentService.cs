using Membership_Management_UI.Models;

namespace Membership_Management_UI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Payment> Add(Payment payment)
        {
            try
            {
                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(payment.MemberPackageID.ToString()), "MemberPackageID");
                formData.Add(new StringContent(payment.PaymentType ?? ""), "PaymentType");
                formData.Add(new StringContent(payment.ActualAmount.ToString() ?? ""), "ActualAmount");
                formData.Add(new StringContent(payment.PaidInAdvance.ToString() ?? ""), "IsActive");

                var response = await _httpClient.PostAsync("api/Payment", formData);
                response.EnsureSuccessStatusCode();
                return payment;
            }
            catch (Exception)
            {

                throw new ArgumentException("field may not valied!");
            }
        }

        public async Task<List<Payment>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Payment>>("api/Payment");
        }

        public async Task<List<Payment>> GetByMember(int id)
        {
            return await _httpClient.GetFromJsonAsync<List<Payment>>($"api/Payment/{id}");
        }
    }
}
