using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Models.Pagination;

namespace TamTechSDK.Common.Services.ContentService.Testimonials.Models
{
    public class TestimonialsList
    {
        public List<TestimonialDto> Data { get; set; }
        public PaginationMetadataModel Pagination { get; set; }
    }
}
