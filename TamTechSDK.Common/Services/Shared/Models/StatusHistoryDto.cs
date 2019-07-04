using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.Shared.Models
{
    public class StatusHistoryDto
    {
        public Guid Id { get; set; }

        public Guid RequestId { get; set; }

        public int CurrentStatusId { get; set; }

        public int PreviousStatusId { get; set; }

        public string UserId { get; set; }

        public string Notes { get; set; }

        public DateTime ProcessDate { get; set; }

        public string CurrentStatusName { get; set; }

        public string PreviousStatusName { get; set; }
    }
}
