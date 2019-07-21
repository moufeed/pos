using Newtonsoft.Json;  

namespace TamTech.Monshaat.POS.MCI.Services.Models
{
    public class AuthenticateADResultModel    : BaseResultModel
    {
        
        [JsonProperty("authresult")]
        public bool AuthResult { get; set; }    
    }
}     