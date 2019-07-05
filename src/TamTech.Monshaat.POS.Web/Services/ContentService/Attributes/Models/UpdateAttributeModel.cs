using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Attributes.Models
{
    public class UpdateAttributeModel : AttributeModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
