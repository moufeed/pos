using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.Models
{
    public class BaseVendorModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("commercialno")]
        public string CommercialNo { get; set; }

        [JsonProperty("municipallicense")]
        public string MunicipalLicense { get; set; }

        [JsonProperty("websiteurl")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("displayorder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("genericfield")]
        public string GenericField { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        //[JsonProperty("mobile")]
        //    public string Mobile { get; set; }

        //[JsonProperty("email")]
        //    public string Email { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}