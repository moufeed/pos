using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.SMS.Models
{
    public class Smslite
    {
        public string Id { get; set; }

        public string Massage { get; set; }

        public List<SmsRecipient> Recipients { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
