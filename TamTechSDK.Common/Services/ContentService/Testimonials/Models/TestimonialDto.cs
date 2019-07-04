using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.ContentService.Models;

namespace TamTechSDK.Common.Services.ContentService.Testimonials.Models
{
    public class TestimonialDto : ContentItem
    {
       public string Company { get; set; }
       public string Postion { get; set; }
       public string Email { get; set; }

       public int Rating { get; set; }
    }
}
