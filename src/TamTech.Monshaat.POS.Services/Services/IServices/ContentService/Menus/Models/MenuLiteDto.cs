using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Menus.Models
{
    public class MenuLiteDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("createddate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("modifieddate")]
        public DateTime? ModifiedDate { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }
    }
}
