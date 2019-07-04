using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.ContentService.Products.Models;

namespace TamTechSDK.Common.Services.ContentService.Reviews.Models
{
    public class Review
    {
        public string Id { get; set; }

        public string Author { get; set; }
         
        public string AuthorId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        public string Text { get; set; }

        public string ReplyText { get; set; }

        public int Rate { get; set; }
         
        public string ProductId { get; set; }
        
        public string ParentId { get; set; }

        public ProductLite Product { get; set; }

        public bool Isapproved { get; set; }
    }
}
