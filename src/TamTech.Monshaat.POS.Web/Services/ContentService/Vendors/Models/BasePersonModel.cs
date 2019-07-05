using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.Models
{
    public class BasePersonModel
    {
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("jobtitle")]
        public string JobTitle { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}