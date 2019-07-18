using Newtonsoft.Json;  

namespace TamTech.Monshaat.POS.MCIServices.Models
{
    public class AuthenticateADResultModel    : BaseResultModel
    {
        
        [JsonProperty("authresult")]
        public bool AuthResult { get; set; }    
    }
}     