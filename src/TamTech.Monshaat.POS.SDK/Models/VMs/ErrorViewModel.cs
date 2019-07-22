using System;

namespace TamTech.Monshaat.POS.Web.SDK.Models.VMs
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}