using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.Shared.Models;

namespace TamTechSDK.Common.Services.ValuesServices.Models
{
    public class ValueModel : BaseLookupModel
    {
        public int AttId { get; set; }

        public int GroupId { get; set; }

        public bool IsOfficial { get; set; }

    }
}
