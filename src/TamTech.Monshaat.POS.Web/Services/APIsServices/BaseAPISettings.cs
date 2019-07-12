namespace TamTech.Monshaat.POS.Web.Services.APIsServices
{
    public class BaseAPISettings
    {
        private const string apiRoot = "https://localhost:44327/api";
        private const string admin = "Admin";
        public readonly string _PortlPath;
        public readonly string _AdminPath;


        public BaseAPISettings(string controller)
        { 
            _PortlPath = $"{apiRoot}/{controller}";
            _AdminPath = $"{apiRoot}/{admin}/{controller}";
        }



        public const string CUTypesController = "CUTypes";
        public const string POSTypesController = "POSTypes";
        public const string POSSectorsController = "POSSectors";
        public const string POSAttributesController = "POSAttributes";
        public const string POSValuesController = "POSValues";
        public const string CURegionsController = "CURegions";


        public const string POSController = "POS";
        public const string POSofVendorController = "Vendor/POS";
        public const string DirectoryController = "Directory/POS";
        public const string ContactUsController = "ContactUs"; 
        public const string VendorsController = "Vendors";

        public const string StatisticsController = "Statistics";
        public const string COmmonContentUtilitiesController = "CCU";

        public const string VendorStatus = "VendorStatus";
        public const string POSStatus = "POSStatus";
        public const string CSStatus = "CSStatus";

        public const string BiographiesController = "Biographies";
        public const string SettingsController = "Settings";

    }
}
