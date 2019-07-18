using Newtonsoft.Json;  

namespace TamTech.Monshaat.POS.MCIServices.Models
{
   public  class BaseResultModel
    {
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
