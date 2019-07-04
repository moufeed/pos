using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Settings.Models
{
    public class SettingModel
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string GenericField { get; set; }

        public string Description { get; set; }
    }
}
