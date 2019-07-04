using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Models.Pagination;

namespace TamTechSDK.Common.Services.ContentService.Products.Models
{
    public class ProductsList
    {
        public List<Product> Data { get; set; }
        public PaginationMetadataModel Pagination { get; set; }
    }
}
