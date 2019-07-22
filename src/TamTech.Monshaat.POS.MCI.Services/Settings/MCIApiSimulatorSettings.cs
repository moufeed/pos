using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.MCI.Services.Settings
{
   public class MCIApiSimulatorSettings     : IMCIApiSettings
    {
        #region Props      
        private readonly string _apirUrl;
        #endregion         

        #region Ctors     
        public MCIApiSimulatorSettings(IHttpContextAccessor  httpContextAccessor,string apiUrl)
        {
            _apirUrl = apiUrl;
            if (string.IsNullOrWhiteSpace(apiUrl))
            {
                var current = httpContextAccessor.HttpContext.Request;
                _apirUrl = string.Format("{0}://{1}{2}", current.Scheme, current.Host, current.PathBase);
            }
        }
        #endregion


        #region  Endpoints Urls     

        public string AuthenticateByAD => $"{_apirUrl}/MCIAPISimulator/v1/GateWayApi/AuthenticateByAD";
        public string GetAllPersonsForCR => $"{_apirUrl}/MCIAPISimulator/v1/GateWayApi/GetAllPersonsForCR";
        public string SendEmail => $"{_apirUrl}/MCIAPISimulator/v1/GateWayApi/SendEmail";

        #endregion

    }
}
