using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.SMS.Models
{
   public class SMSModel
    { 
        public string to { get; set; }

        public string body { get; set; }

        public Dictionary<string, string> properties { get; set; }

    }
}
