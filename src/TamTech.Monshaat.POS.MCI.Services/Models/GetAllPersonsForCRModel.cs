using Newtonsoft.Json;  

namespace TamTech.Monshaat.POS.MCI.Services.Models
{
    public class GetAllPersonsForCRModel
    {                 
        [JsonProperty("cr")]
        public string CR { get; set; }
    }
}
