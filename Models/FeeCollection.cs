using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Membership_Management_UI.Models
{
    public class FeeCollection
    {


        public int CollectionId { get; set; }

        public DateTime CollectionDate { get; set; }

        public string? CollectionType { get; set; }
        public decimal Amount { get; set; }

        public int MemberId { get; set; }

        public Member? Member { get; set; }


    }
}
