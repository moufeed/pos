using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.EFile2.Utilities
{
    public class Helpers
    {
        #region Props
        //public static string VendorRole
        //{
        //    get
        //    {
        //        return vendorRole;
        //    }
        //    set
        //    {
        //        if (!vendorRoleIsLocked)
        //        {
        //            vendorRoleIsLocked = true;
        //            vendorRole = value;
        //        }
        //    }

        //}

        //private static string vendorRole;
        //private static bool vendorRoleIsLocked;

          public static int LogoutAfterMinutes
        {
            get
            {
                return logoutAfterMinutes;
            }
            set
            {
                if (!logoutAfterMinutesIsLocked)
                {
                    logoutAfterMinutesIsLocked = true;
                    logoutAfterMinutes = value;
                }
            }

        }

        private static int logoutAfterMinutes;
        private static bool logoutAfterMinutesIsLocked;


        #endregion

      

    }
}
