using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.MCIServices.Settings
{
   public class MCIApiSimulatorSettings     : IMCIApiSettings
    {
        #region Props      
        private readonly string _apirUrl;
        #endregion         

        #region Ctors     
        public MCIApiSimulatorSettings()
        {
            _apirUrl = "https://localhost:44327";
        }
        #endregion


        #region  Endpoints Urls     

        public string AuthenticateByAD => $"{_apirUrl}/MCIAPISimulator/v1/GateWayApi/AuthenticateByAD";

        #endregion

    }
}
