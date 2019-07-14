using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Services.POSs.Models
{
   public class PosDto : PosBaseDto
    {
        [JsonProperty("specifications")]
        public List<SpecificationDto> Specifications { get; set; }
        [JsonProperty("statushistories")]
        public List<POSStatusHistoryDto> StatusHistories { get; set; }
        [JsonProperty("images")]
        public List<string> Images { get; set; }

       
    }
}
