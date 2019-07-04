using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Request.Models
{
    public class RequestModel
    {
        public Guid? ItemId { get; set; }

        public int CityId { get; set; }

        public int StatusId { get; set; }

        public int? Quantity { get; set; }

        public double? ItemPrice { get; set; }

        public string FullName { get; set; }
  
        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string Notes { get; set; }
    }
}
