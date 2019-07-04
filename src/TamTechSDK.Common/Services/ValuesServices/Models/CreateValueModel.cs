using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ValuesServices.Models
{
    public class CreateValueModel : ValueModel
    {
        public bool IsOfficial { get; set; }

        public int GroupId { get; set; }
    }
}
