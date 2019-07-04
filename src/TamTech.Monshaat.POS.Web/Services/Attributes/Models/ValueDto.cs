using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.Shared.Models;

namespace TamTechSDK.Common.Services.Attributes.Models
{
    public class ValueDto : BaseLookupDto
    {
        public int AttId { get; set; }

        public int Number { get; set; }

        public string Text { get; set; }

        public bool Checked { get; set; }

    }
}
