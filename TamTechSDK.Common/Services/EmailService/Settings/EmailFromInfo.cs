using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.Email.Settings
{
    public class EmailFromInfo
    {
        public string From { get; set; }
        public string FromName { get; set; }
        public List<string> CC { get; set; }
    }

}
