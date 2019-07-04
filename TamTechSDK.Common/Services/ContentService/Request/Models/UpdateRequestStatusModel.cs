using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Request.Models
{
    public class UpdateRequestStatusModel
    {
        public Guid Id { get; set; }

        public int CurrentStatusId { get; set; }

        public int StatusId { get; set; }

        public string Notes { get; set; }
    }
}
