using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.Shared.Models
{
    public class BaseLookupModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string Slug { get; set; }

        public string Tags { get; set; }

        public int DisplayOrder { get; set; }

        public string GenericField { get; set; }

        public string Lang { get; set; }

        public string Image { get; set; }

    }
}
