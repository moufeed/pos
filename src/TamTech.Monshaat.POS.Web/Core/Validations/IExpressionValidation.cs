using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Core.Validations
{
    public interface IExpressionValidation
    {
        bool MobileIsFormatted(string mobileNumber);

        bool EmailIsFormatted(string email);
    }
}
