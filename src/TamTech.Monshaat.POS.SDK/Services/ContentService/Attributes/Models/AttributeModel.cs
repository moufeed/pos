using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Attributes.Models
{
    public class AttributeModel : BaseLookupModel
    {

        [JsonProperty("choicetype")]
        public int ChoiceType { get; set; }

        [JsonProperty("inputtype")]
        public int InputType { get; set; }

        [JsonProperty("ismandatory")]
        public bool IsMandatory { get; set; }

    }
}
