using Newtonsoft.Json;
 
namespace TamTech.Monshaat.POS.Web.Core.Helpers
{
    public class Helpers
    { 
        public static T Deserialize<T>(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return default(T);
            return JsonConvert.DeserializeObject<T>(value);
        }

    }
}
