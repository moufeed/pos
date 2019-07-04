using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Models.Shared
{
    public class TreeItem<T>
    {
        public T Item { get; set; }
        public IEnumerable<TreeItem<T>> Children { get; set; }
    }
}
