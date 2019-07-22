using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Pages.Models
{
    public class HtmlPage : PageDto
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

     
}
