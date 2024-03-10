using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Membership_Management_UI.Models
{
    public class DuePayment
    {
       
        public int DuePaymentID { get; set; }
        public int MemberPackageID { get; set; }
       
        public MemberPackage? MemberPackage { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? Amount { get; set; }
    }
}
