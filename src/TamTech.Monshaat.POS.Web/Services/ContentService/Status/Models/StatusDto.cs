using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Status.Models
{
   public  class StatusDto
    {
        
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("options")]
        public string Options { get; set; }
        
        [JsonProperty("genericfield")]
        public string GenericField { get; set; }
        
        [JsonProperty("displayorder")]
        public int DisplayOrder { get; set; }
        
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
