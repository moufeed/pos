using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.SDK.Models.Settings
{
    public class SeriLogSettingsModel
    {
        public string PathFormat { get; set; }
        public string MinimumLevel { get; set; }
        public long? FileSizeLimitBytes { get; set; }

    }
}
