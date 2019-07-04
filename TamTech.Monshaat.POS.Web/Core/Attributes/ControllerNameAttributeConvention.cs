using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TamTechSDK.Web.Attributes
{
    public class ControllerNameAttributeConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var controllerNameAttribute = controller.Attributes.OfType<ControllerNameAttribute>().SingleOrDefault();
            if (controllerNameAttribute != null)
            {
                controller.ControllerName = controllerNameAttribute.Name;
            }
        }
    }
}
