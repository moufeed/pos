using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TamTechSDK.Web.Services.Validations.Settings;
namespace TamTechSDK.Web.Services.Validations
{
    public class ExpressionValidation : IExpressionValidation
    {

        private readonly RegexExpressionsSettings settings;
        public ExpressionValidation(RegexExpressionsSettings settings)
        {
            this.settings = settings;

        }

        public ExpressionValidation() :
            this(new RegexExpressionsSettings
            {
                EmailFormat = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*",
                MobileFormat = "^(\\+\\d{1,3}[- ]?)?\\d{10}$"
            })
        {

        }

        public bool MobileIsFormatted(string mobileNumber)
        {
            return Regex.IsMatch(mobileNumber, settings.MobileFormat);
        }

        public bool EmailIsFormatted(string email)
        {
            return Regex.IsMatch(email, settings.EmailFormat);
        }
    }
}
