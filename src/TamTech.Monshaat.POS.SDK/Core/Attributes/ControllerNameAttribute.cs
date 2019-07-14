using System; 

namespace TamTech.Monshaat.POS.Web.Core.Attributes
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
