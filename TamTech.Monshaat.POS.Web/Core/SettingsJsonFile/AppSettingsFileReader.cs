//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using TamTech.Monshaat.POS.EFile2.Utilities.Services;
//using TamTech.Monshaat.POS.Web.Services.Configurations.AppSetting.Constants;
//using TamTechSDK.Common.Services.Email.Settings;
//using TamTechSDK.Web.Models.Admin.Menus;
//using TamTechSDK.Web.Services.Configurations.AppSetting;

//namespace TamTech.Monshaat.POS.Web.Services.Configurations.AppSetting
//{
//    public class AppSettingsFileReader : IAppSettingsFile, IAppSettingsService
//    {

//        #region Props 
//        private readonly IConfiguration _configuration;
//        private readonly string _contentsInfo;
//        private readonly string _webApplicationSettings;
//        private readonly string _directBackendSDKsSettings;
//        private readonly string _emailServiceSettings;
//        private readonly string _displayTokenInWebView;
//        private readonly string _cacheMenus;
//        private readonly string _microServicesSettings;
//        private readonly string _identityServiceSettingsSection;
//        private readonly string _contentnsServiceSettingsSection;
//        private readonly string _uploadServiceSettingsSection;
//         private readonly string _staticPagesMenu;
//        private readonly string _webApplication_Configuration;
//        private readonly string _webApplication_ContentsInfo;
//        private readonly string _homePageConfig;
//        private readonly string _vendorRoleName;
//        #endregion

//        #region Ctors 
//        public AppSettingsFileReader(IConfiguration configuration,
//                                                string webApplicationSettings = AppSettings.WebApplicationSettings,
//                                                string directBackendSDKsSettings = AppSettings.DirectBackendSDKsSettings,
//                                                string emailServiceSettings = AppSettings.DirectBackendSDK_EmailService_Settings,
//                                                string displayTokenInWebView = AppSettings.WebApplication_DisplayTokenInWebView,
//                                                string cacheMenus = AppSettings.WebApplication_CacheMenus,
//                                                string contentsInfo = AppSettings.WebApplication_ContentsInfo,
//                                                string microServicesSettings = AppSettings.MicroServicesSettings,
//                                                string identityServiceSettingsSection = AppSettings.MicroServices_IdentityService,
//                                                string contentnsServiceSettingsSection = AppSettings.MicroServices_ContentsService,
//                                                string uploadServiceSettingsSection = AppSettings.MicroServices_UploadService,
//                                               string staticPagesMenu = AppSettings.StaticPages,
//                                                string webApplication_Configuration = AppSettings.WebApplication_Configuration,
//                                                string webApplication_ContentsInfo = AppSettings.WebApplication_ContentsInfo,
//                                                string homePageConfig = AppSettings.homePageConfig,
//                                                string vendorRoleName = AppSettings.WebApplication_VendorRoleName
//                                                )
//        {
//            _configuration = configuration;
//            _webApplicationSettings = webApplicationSettings;
//            _directBackendSDKsSettings = directBackendSDKsSettings;
//            _emailServiceSettings = emailServiceSettings;
//            _displayTokenInWebView = displayTokenInWebView;
//            _cacheMenus = cacheMenus;
//            _contentsInfo = contentsInfo;
//            _microServicesSettings = microServicesSettings;
//            _identityServiceSettingsSection = identityServiceSettingsSection;
//            _contentnsServiceSettingsSection = contentnsServiceSettingsSection;
//            _uploadServiceSettingsSection = uploadServiceSettingsSection;
//           _staticPagesMenu = staticPagesMenu;
//            _webApplication_Configuration = webApplication_Configuration;
//            _webApplication_ContentsInfo = webApplication_ContentsInfo;
//            _homePageConfig = homePageConfig;
//            _vendorRoleName =  vendorRoleName;
//        }
//        #endregion



//        #region portal
//        public Guid GetHomePageSummuryId()
//        {
//            Guid id = _configuration.GetSection(_webApplicationSettings).GetSection(_contentsInfo).GetSection(_homePageConfig).GetValue<Guid>("HomePageSummuryId");
//            return id;
//        }
//        public string GetMainMenuKey()
//        {
//            string key = _configuration.GetSection(_webApplicationSettings).GetSection(_contentsInfo).GetSection(_homePageConfig).GetValue<string>("MainMenuSlug");
//            return key;
//        }

//        public string GetHomePageMainSliderKey()
//        {
//            string key = _configuration.GetSection(_webApplicationSettings).GetSection(_contentsInfo).GetSection(_homePageConfig).GetValue<string>("HomePageMainSlider");
//            return key;
//        }


//        public string GetHomePageCarouselSliderKey()

//        {
//            string key = _configuration.GetSection(_webApplicationSettings).GetSection(_contentsInfo).GetSection(_homePageConfig).GetValue<string>("HomePageCarouselSlider");
//            return key;
//        }

//        public Dictionary<string, string> HomePageConfig()
//        {
//            return _configuration.GetSection(_webApplicationSettings).GetSection(_contentsInfo).GetSection(_homePageConfig).Get<Dictionary<string, string>>();
//        }
//        #endregion



//        public string GetIdentityServiceUrl()
//        {
//            string url = _configuration.GetSection(_microServicesSettings).GetSection(_identityServiceSettingsSection).GetValue<string>("Url");
//            return url;
//        }



//        public string GetContentServiceUrl()
//        {
//            string url = _configuration.GetSection(_microServicesSettings).GetSection(_identityServiceSettingsSection).GetValue<string>("Url");
//            return url;
//        }



//        public string GetUploadServiceUrl()
//        {
//            string url = _configuration.GetSection(_microServicesSettings).GetSection(_identityServiceSettingsSection).GetValue<string>("Url");
//            return url;
//        } 

//        public  string  GetVendorRoleName()
//        {
//            string role = _configuration.GetSection(_webApplicationSettings).GetValue<string>(_vendorRoleName);

//            return role;
//        }













//    }
//}
