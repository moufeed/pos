using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Services.POSs.Models
{

    public class BaseSpecificationModel
    {
        [JsonProperty("attid")]
        public int AttId { get; set; }

        [JsonProperty("inputtype")]
        public int InputType { get; set; }

        [JsonProperty("values")]
        public List<int> Values { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }


    public class SpecificationModel : BaseSpecificationModel
    {
         
    }
}
