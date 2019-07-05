using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Models.Dtos.Common
{
    public class StatusHistoryDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("requestid")]
        public Guid RequestId { get; set; }

        [JsonProperty("currentstatusid")]
        public int CurrentStatusId { get; set; }

        [JsonProperty("previousstatusid")]
        public int PreviousStatusId { get; set; }

        [JsonProperty("userid")]
        public string UserId { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("processdate")]
        public DateTime ProcessDate { get; set; }

        [JsonProperty("currentstatusname")]
        public string CurrentStatusName { get; set; }

        [JsonProperty("previousstatusname")]
        public string PreviousStatusName { get; set; }
    }
}
