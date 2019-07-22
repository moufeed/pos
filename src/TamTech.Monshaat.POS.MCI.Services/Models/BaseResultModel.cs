using Newtonsoft.Json;  

namespace TamTech.Monshaat.POS.MCI.Services.Models
{
   public  class BaseResultModel
    {
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
