using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.SDK.Services.Email.Models
{
    public class EmailModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string HtmlMessage { get; set; }

        public string ReasonOfSend { get; set; }

        public List<string> CC { get; set; }
    }
}
