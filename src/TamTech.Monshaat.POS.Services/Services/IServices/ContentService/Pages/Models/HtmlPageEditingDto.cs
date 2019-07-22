using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Pages.Models
{
    public class EditHtmlPageDto :PageModel
    {
        [Required]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("htmlcontent")]
        public string Content { get; set; }


    }
}
