using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.MCI.Services.Models
{
    public class SendEmailModel
    {

        [JsonProperty("To")]
        public List<string> To { get; set; }

        [JsonProperty("cc")]
        public List<string> CC { get; set; }

        [JsonProperty("bcc")]
        public List<string> Bcc { get; set; }

        [JsonProperty("TemplateCode")]
        public string TemplateCode { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("BodyParameters")]
        public List<string> BodyParameters { get; set; }
    }
}
