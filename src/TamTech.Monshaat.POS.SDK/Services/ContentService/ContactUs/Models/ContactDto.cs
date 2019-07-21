using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.ContactUs.Models
{
    public  class ContactDto : ContactBaseModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("statusid")]
        public int StatusId { get; set; }

        [JsonProperty("statusoptions")]
        public string StatusOptions { get; set; }

        [JsonProperty("createddate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("modifieddate")]
        public DateTime? ModifiedDate { get; set; }

        [JsonProperty("replay")]
        public string Replay { get; set; }

        [JsonProperty("statusname")]
        public string StatusName { get; set; }
 
        [JsonProperty("typename")]
        public string TypeName { get; set; }

        [JsonProperty("attachments")]
        public List<string> Attachments { get; set; }

            
    }   
}
