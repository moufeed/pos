using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.SDK.Services.POSs.Models
{
    public class POSStatusHistoryDto : StatusHistoryDto
    {
        [JsonProperty("actionid")]
        public int ActionId { get; set; }

        [JsonProperty("actionname")]
        public string ActionName { get; set; }
    }
}
