using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Models.Dtos.Common
{
    public class BaseLookupDto : BaseLookupModel
    {
        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("IsOfficial")]
        public bool IsOfficial { get; set; }

        [JsonProperty("GroupId")]
        public int GroupId { get; set; }

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("createddate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("modifieddate")]
        public DateTime? ModifiedDate { get; set; }

        [JsonProperty("modifieruserid")]
        public string ModifierUserId { get; set; }

        [JsonProperty("creatoruserid")]
        public string CreatorUserId { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }
    }
}
