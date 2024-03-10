﻿
using System.Text.Json.Serialization;

namespace Membership_Management_UI.Models
{
    public class MemberPackage
    {
       
        public int MemberPackageID { get; set; }

        public int MemberID { get; set; }
        
        public Member? Member { get; set; }

        public int PackageID { get; set; }
        
        public Package? Package { get; set; }

        public int? Quantity { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool? IsActive { get; set; }


        public virtual ICollection<DuePayment>? DuePayment { get; set; }
        public virtual ICollection<Payment>? Payment { get; set; }

    }
}
