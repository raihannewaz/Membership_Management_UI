using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;

namespace Membership_Management_UI.Models
{
    public class Member
    {

        public int MemberId { get; set; }
        public string? Name { get; set; }
        public int? Phone { get; set; }
        public string? PresentAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public string? Photo { get; set; }


        public DateTime? Dob { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ActivaitonDate { get; set; }
        public DateTime? ExpDate { get; set; }
        public bool? IsActive { get; set; }

        public string? ActionType { get; set; }
        public DateTime? ActionDate { get; set; }


        public IBrowserFile? ImageFile { get; set; }


    }
}
