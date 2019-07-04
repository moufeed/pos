using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Services.Validations
{
    public interface IExpressionValidation
    {
        bool MobileIsFormatted(string mobileNumber);

        bool EmailIsFormatted(string email);
    }
}
