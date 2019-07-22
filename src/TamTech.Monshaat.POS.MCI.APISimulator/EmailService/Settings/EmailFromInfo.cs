using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.MCI.APISimulator.EmailService
{
    public class EmailFromInfo
    {
        public string From { get; set; }
        public string FromName { get; set; }
        public List<string> CC { get; set; }
    }

}
