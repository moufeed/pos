 

namespace TamTech.Monshaat.POS.MCI.EFile2.Utilities
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

          public static int DurationOfLogin
        {
            get
            {
                return durationOfLogin;
            }
            set
            {
                if (!durationOfLoginIsLocked)
                {
                    durationOfLoginIsLocked = true;
                    durationOfLogin = value;
                }
            }

        }

        private static int durationOfLogin;
        private static bool durationOfLoginIsLocked;


        #endregion

      

    }
}
