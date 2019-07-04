using System.Collections.Generic;

namespace TamTech.Monshaat.POS.Web.Core.Cultures

{
    public static class CultureConstants
    {

        public static readonly CultureModel DefaultCulture = new CultureModel
        {
            Name = "العربية",
            Culture = "ar",
            Lang = "ar"
        };

        public static readonly List<CultureModel> CulturesList = new List<CultureModel>
        {
            DefaultCulture,
           
        };
        public static readonly string Constraint = DefaultCulture.Culture.Length == 2 ? "^([a||e||t||f||d])+([r||n||r||e])$" : "^([ar||en]{2})+(-)+([ar||en]{2})$";
       
    }
}
