using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.ContactUs.Models
{
    public class ReplayContactUsModel
    {
        
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("replay")]
        public string Replay { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
    }
}
