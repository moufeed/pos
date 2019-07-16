using System;

namespace TamTech.Monshaat.POS.MCI.APISimulator
{
    public class MCIAPISecret
    {
        #region Props    
        public readonly string ApiSecret;    
        #endregion


        #region Ctors
        public MCIAPISecret(string apiSecret)
        {
            ApiSecret = apiSecret;
        }
        #endregion
    }
}
