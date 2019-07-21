using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.Models
{
    public class VendorDto : BaseVendorModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("statusname")]
        public string StatusName { get; set; }

        [JsonProperty("statusoptions")]
        public string StatusOptions { get; set; }

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

        [JsonProperty("activated")]
        public bool Activated { get; set; }

        [JsonProperty("adminactionable")]
        public bool AdminActionable { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("groupid")]
        public int GroupId { get; set; }
        [JsonProperty("statushistories")]
        public List<VendorStatusHistoryDto> StatusHistories { get; set; }
    }
}
