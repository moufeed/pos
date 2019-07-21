using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.MCI.Services.Settings
{
   public class MCIApiSettings : IMCIApiSettings
    {
        #region Props      
        private readonly string _apirUrl;
        #endregion         

        #region Ctors     
        public MCIApiSettings(string apiUrl)
        {
            _apirUrl = apiUrl;
        }
        #endregion


        #region  Endpoints Urls     

        public string AuthenticateByAD => $"{_apirUrl}/AuthenticateByAD";
        public string GetAllPersonsForCR => $"{_apirUrl}/GetAllPersonsForCR";
        public string SendEmail => $"{_apirUrl}/SendEmail";

        #endregion

    }
}
