using Newtonsoft.Json;  

namespace TamTech.Monshaat.POS.MCIServices.Models
{
    public class GetAllPersonsForCRModel
    {                 
        [JsonProperty("cr")]
        public string CR { get; set; }
    }
}
