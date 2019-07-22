using System; 

namespace TamTech.Monshaat.POS.Web.SDK.Core.Attributes
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
