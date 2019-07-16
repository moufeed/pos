using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.MCIServices.Settings
{
   public class MCIApiSettings
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

        #endregion

    }
}
