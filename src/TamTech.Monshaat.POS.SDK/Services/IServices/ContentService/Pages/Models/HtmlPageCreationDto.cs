using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Pages.Models
{
    public class CreateHtmlPageDto : PageModel
    {

        [Required]
        [JsonProperty("htmlcontent")]
        public string Content { get; set; }
    }
}
