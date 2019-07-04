using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Constants
{
    public static class ContentSDKPoliciesConstants
    {
        /// <summary>
        /// General roles :
        /// Super admin can give the super admin role to other users
        /// Author is the user who write content to be reviewed
        /// Editor is the user who publish/unpublish the content to be available for access
        /// ContentAdmin can do crud operations
        /// </summary>


        public const string ContactUsAdmin = "ContactUsAdmin";
        public const string ContactUsTypesAdmin = "ContactUsTypesAdmin";
        public const string ContactUsStatusAdmin = "ContactUsStatusAdmin";
        public const string POSAdmin = "POSAdmin";
        public const string POSTypesAdmin = "POSTypesAdmin";
        public const string POSSectorsAdmin = "POSSectorsAdmin";
        public const string POSStatusAdmin = "POSStatusAdmin";
        public const string POSAttributesAdmin = "POSAttributesAdmin";
        public const string VendorAdmin = "VendorAdmin";
        public const string RequestAdmin = "RequestAdmin";
        public const string TestimonialsAdmin = "TestimonialsAdmin";
        public const string Vendor = "Vendor";




        // Menus related policies
        public const string MenusContentAdmin = "MenusContentAdmin";

        // Sliders related policies
        public const string SlidersContentAdmin = "SlidersContentAdmin";

        // Pages related policies
        public const string PagesContentAdmin = "PagesContentAdmin";

        // Users related policies
        public const string UsersAdmin = "UsersAdmin";

        // Galleries related policies
        public const string GalleriesContentAdmin = "GalleriesContentAdmin";

        // Services related policies
        public const string ServicesContentAdmin = "ServicesContentAdmin";

        // Posts related policies
        public const string PostsContentAdmin = "PostsContentAdmin";
        public const string PostsEditor = "PostsEditor";
        public const string PostAuthor = "PostAuthor";

        // Products related policies
        public const string ProductsContentAdmin = "ProductsContentAdmin";

        // Dashboard related policies
        public const string DashboardAdmin = "DashboardAdmin";


    }
}
