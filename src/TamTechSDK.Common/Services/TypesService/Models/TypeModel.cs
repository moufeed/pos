using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.Shared.Models;

namespace TamTechSDK.Common.Services.TypesService.Models
{
    public class TypeModel : BaseLookupModel
    {
        public int? ParentId { get; set; }

        public Dictionary<string, object> Options { get; set; }
    }
}
