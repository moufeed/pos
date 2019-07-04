using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Attributes
{
   public class ControllerNameAttribute : Attribute
    {
        public string Name { get; }

        public ControllerNameAttribute(string name)
        {
            Name = name;
        }
    }
}
