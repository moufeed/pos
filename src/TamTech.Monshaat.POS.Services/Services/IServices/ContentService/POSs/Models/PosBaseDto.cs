using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Services.POSs.Models
{
   public  class PosBaseDto : BasePosModel
    {
        [JsonProperty("vendorname")]
        public string VendorName { get; set; }

        [JsonProperty("vendorwebsite")]
        public string VendorWebsite { get; set; }
        [JsonProperty("vendorphone")]
        public string VendorPhone { get; set; }
        [JsonProperty("typename")]
        public string TypeName { get; set; }

        [JsonProperty("sectorname")]
        public string SectorName { get; set; }

        [JsonProperty("statusname")]
        public string StatusName { get; set; }

        [JsonProperty("statusoptions")]
        public string StatusOptions { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("statusid")]
        public int StatusId { get; set; }

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

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("actionable")]
        public bool Actionable { get; set; }

        [JsonProperty("approved")]
        public bool Approved { get; set; }

        [JsonProperty("vendoremail")]
        public string VendorEmail { get; set; }
    }
}
