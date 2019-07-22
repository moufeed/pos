 

namespace TamTech.Monshaat.POS.Web.SDK.Core.Constants
{      /// <summary>
       /// General roles :
       /// Super admin can give the super admin role to other users
       /// Author is the user who write content to be reviewed
       /// Editor is the user who publish/unpublish the content to be available for access
       /// ContentAdmin can do crud operations
       /// </summary>
    public static class PolicyConstants
    {
        public const string AuthenticatedUser = "AuthenticatedUser";

        public const string ContactUsAdmin = "ContactUsAdmin";
        public const string ContactUsTypesAdmin = "ContactUsTypesAdmin";
        public const string ContactUsStatusAdmin = "ContactUsStatusAdmin";

        public const string POSAdmin = "POSAdmin";
        public const string POSTypesAdmin = "POSTypesAdmin";
        public const string POSSectorsAdmin = "POSSectorsAdmin";
        public const string POSStatusAdmin = "POSStatusAdmin";
        public const string POSAttributesAdmin = "POSAttributesAdmin";

        public const string VendorAdmin = "VendorAdmin";
        public const string Vendor = "Vendor";

        public const string MenusContentAdmin = "MenusContentAdmin";
        public const string SlidersContentAdmin = "SlidersContentAdmin";
        public const string PagesContentAdmin = "PagesContentAdmin";
        public const string UsersAdmin = "UsersAdmin";

        public const string DashboardAdmin = "DashboardAdmin";
        public const string AdminAccess = "AdminAccess";
        public const string ConfigurationsAdmin = "ConfigurationsAdmin";
        public const string BiographiesAdmin = "BiographiesAdmin";

        public const string IdentityUserAccess = "IdentityUserAccess";
        public const string IdentityManager = "IdentityManager";         
    }
}
