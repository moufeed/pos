using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Pages.Models
{
    public class SectionsPage : PageDto
    {
        public Dictionary<string, string> Content { get; set; } = new Dictionary<string, string>();
    } 
}
