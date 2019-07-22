using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Biographies.Models
{
    public class UpdateBiographyModel
    {
        [JsonProperty("groupid")]
        public int GroupId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("biographies")]
        public List<BiographyModel> Biographies { get; set; }
    }
}
