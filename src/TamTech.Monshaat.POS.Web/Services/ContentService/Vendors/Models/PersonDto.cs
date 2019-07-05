using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.Models
{
    public class PersonDto : BasePersonModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("createddate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("modifieddate")]
        public DateTime? ModifiedDate { get; set; }

        [JsonProperty("modifieruserid")]
        public string ModifierUserId { get; set; }

        [JsonProperty("creatoruserid")]
        public string CreatorUserId { get; set; }

        [JsonProperty("clientid")]
        public string ClientId { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; } 

        [JsonProperty("vendor")]
        public VendorDto Vendor { get; set; }

        [JsonProperty("identityno")]
        public string IdentityNo { get; set; }


    }
}
