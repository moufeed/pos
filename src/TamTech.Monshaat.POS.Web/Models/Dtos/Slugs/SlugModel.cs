

using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Models.Dtos.Slugs
{
    public class SlugModel
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}
