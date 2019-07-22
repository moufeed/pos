using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Pages.Models
{
    public  class CreateSectionsPageDto : PageModel
    {
        [JsonProperty("sectionscontent")]
        public Dictionary<string, string> Content { get; set; }
    }
}
