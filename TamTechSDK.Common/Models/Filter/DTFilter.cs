using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Models.Filter
{
    public class DTFilter
    {
        public Dictionary<string, object> Search { get; set; }

        public string SortBy { get; set; }

        public bool Descending { get; set; }

        public string Lang { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
