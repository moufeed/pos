using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Pages.Models
{
    public class SectionsPage : PageDto
    {
        [JsonProperty("content")]
        public Dictionary<string, string> Content { get; set; } = new Dictionary<string, string>();
    } 
}
