using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace TamTech.Monshaat.POS.Web.Services.ContentService.ContactUs.Models
{
    public class ContactBaseModel
    {
        [JsonProperty("fullname")]
        public string FullName { get; set; }

         [JsonProperty("email")]
        public string Email { get; set; }

         [JsonProperty("mobile")]
        public string Mobile { get; set; }

         [JsonProperty("phone")]
        public string Phone { get; set; }

         [JsonProperty("message")]
        public string Message { get; set; }

         [JsonProperty("subject")]
        public string Subject { get; set; }

         [JsonProperty("companyname")]
        public string CompanyName { get; set; }

         [JsonProperty("notes")]
        public string Notes { get; set; }

         [JsonProperty("cityid")]
        public int? CityId { get; set; }

         [JsonProperty("countryid")]
        public int? CountryId { get; set; }

         [JsonProperty("regionid")]
        public int? RegionId { get; set; }

         [JsonProperty("genericfield")]
        public string GenericField { get; set; }

         [JsonProperty("cityname")]
        public string CityName { get; set; }

         [JsonProperty("regionname")]
        public string RegionName { get; set; }

         [JsonProperty("countryname")]
        public string CountryName { get; set; }
    }
}
