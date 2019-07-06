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

    }
}
