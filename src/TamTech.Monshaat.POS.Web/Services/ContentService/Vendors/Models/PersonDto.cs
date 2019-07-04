using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.Models
{
    public class PersonDto : BasePersonModel
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifierUserId { get; set; }

        public string CreatorUserId { get; set; }

        public string ClientId { get; set; }

        public bool Locked { get; set; } 

        public VendorDto Vendor { get; set; }

        public string IdentityNo { get; set; }


    }
}
