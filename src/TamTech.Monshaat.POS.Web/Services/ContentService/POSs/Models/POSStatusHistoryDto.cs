using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.Services.POSs.Models
{
    public class POSStatusHistoryDto : StatusHistoryDto
    {
        [JsonProperty("actionid")]
        public int ActionId { get; set; }

        [JsonProperty("actionname")]
        public string ActionName { get; set; }
    }
}
