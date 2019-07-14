using Microsoft.AspNetCore.Http;
 

namespace TamTech.Monshaat.POS.Web.Core.Cultures
{
    public static class DataCultureHelper
    {
        /// <summary>
        ///  this method useing when call CRUD oprations from bussines logic (Services) to get data by activated language 
        /// </summary>
        /// <returns>string : activated language [en/ar] </returns>
        public static string GetCurrent(IQueryCollection queries)
        { 
            return System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        }
    }
}
