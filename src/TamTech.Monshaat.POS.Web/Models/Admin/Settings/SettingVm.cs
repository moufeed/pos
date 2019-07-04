using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Models.Admin.Biographies
{
    public class SettingVm
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public string Key { get; set; }

        public string SharedKey { get; set; }

        public string Value { get; set; }

        public bool Enabled { get; set; }

        public bool Lasted { get; set; }

        public bool Updated { get; set; }

        public string GenericField { get; set; }

        public string Description { get; set; }
    }
}
