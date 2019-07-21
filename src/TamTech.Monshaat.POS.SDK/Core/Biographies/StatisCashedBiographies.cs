using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Shared.Biography;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Biographies;
using TamTech.Monshaat.POS.Web.SDK.Core.Mappers.Biography;

namespace TamTech.Monshaat.POS.Web.SDK.Core.Biographies
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
            _biographyInfo = dto?.Data?.MapToBiographyInfoModel();
            _biographyInfo.Lang = _lang;

        }


        #endregion
    }
}
