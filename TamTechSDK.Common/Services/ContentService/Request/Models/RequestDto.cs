using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Request.Models
{
   public class RequestDto : RequestModel
    {

        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public string StatusName { get; set; }

        public string CityName { get; set; }
    }
}
