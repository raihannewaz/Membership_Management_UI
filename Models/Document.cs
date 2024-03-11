using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.Forms;

namespace Membership_Management_UI.Models
{
    public class Document
    {
       
        public int DocId { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentLocation { get; set; }

        public int MemberId { get; set; }


        public string Member { get; set; }

        public string? ActionType { get; set; }
        public DateTime? ActionDate { get; set; }


        public IBrowserFile? NidFile { get; set; }

        public IBrowserFile? UtilityFile { get; set; }



        public enum EDocType
        {
            Nid,
            UtilityBill
        }

    }
}
