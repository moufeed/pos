using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Shared.Biography;
using TamTechSDK.Common.Services.ContentService.Biography;
using TamTechSDK.Web.Extensions.AutoMapper.Biography;

namespace TamTech.Monshaat.POS.Web.Core.Biographies
{
    public class StatisCashedBiographies : IBiographiesManager
    {


        #region Props  
        private static BiographyInfoVm _biographyInfo;


        private readonly IBiographyService _biographyService;
        private readonly string _lang;
        // private readonly IAppSettingsFile _appSettingsService;
        #endregion


        #region Ctors
        public StatisCashedBiographies(IBiographyService biographyService
            //, IAppSettingsFile appSettingsService
            )
        {
            _biographyService = biographyService;
            _lang = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if (_biographyInfo != null)
            {
                _biographyInfo.InvokedCount++;
            }
            //   _appSettingsService = appSettingsService;
        }
        #endregion




        #region Utilities

        public async Task<BiographyInfoVm> GetInfoAsync()
        {
            if (_biographyInfo == null || !_biographyInfo.Lang.Equals(_lang))
            {
                await ReloadInfoAsync();
            }
            return _biographyInfo;
        }


        public async Task ReloadInfoAsync()
        {
            var dto = await _biographyService.GetAllAsync();
            _biographyInfo = dto.MapToBiographyInfoModel();
            _biographyInfo.Lang = _lang;

        }


        #endregion
    }
}
