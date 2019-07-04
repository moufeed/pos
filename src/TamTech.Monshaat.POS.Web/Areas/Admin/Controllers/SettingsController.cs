using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.Core.Biographies;
using TamTechSDK.Common.Services.ContentService.Biography;
using TamTechSDK.Common.Services.ContentService.Biography.Models;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Common.Services.Upload.Models;
using TamTechSDK.Web.Extensions.AutoMapper.Biography;
using TamTechSDK.Web.Models.Admin.Biographies;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    public class SettingsController : AdminBaseController
    {

        private readonly IBiographyService _settingsServices;
        private readonly IStringLocalizer<AdminBaseController> _localizer;
        private readonly IUploadManagerService _uploadManager;
        private readonly IBiographiesManager _biographiesManager;
        public SettingsController(ITelemetryService telemetryClientService,
            IStringLocalizer<AdminBaseController> localizer,
            IBiographyService settingsServices,
            IUploadManagerService uploadManager, IBiographiesManager biographiesManager
            ) : base(telemetryClientService, localizer)
        {
            _settingsServices = settingsServices;
            _uploadManager = uploadManager;
            _localizer = localizer;
            _biographiesManager = biographiesManager;
        }


        private async Task DeleteFilesAsync(string img)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(img))
                {
                    Dictionary<string, FileTypesEnum> deleteInputModel = new Dictionary<string, FileTypesEnum> { { img, FileTypesEnum.General } };
                    Common.Providers.Requests.Models.IRequestProviderResult<Common.Services.Upload.Models.DeleteFilesModelResult> uploadResult = await _uploadManager.DeleteFilesAsync(deleteInputModel);
                    TrackIfNotFilesDeleted(uploadResult.Success, uploadResult.StatusCode, uploadResult.Data, deleteInputModel);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
            }

        }

        [HttpGet("{Culture}/[Area]/[Controller]")]
        public virtual async Task<IActionResult> Index()
        {

            return View();
        }

        [HttpGet("{Culture}/[Area]/[Controller]/[Action]")]
        public virtual async Task<IActionResult> Information()
        {
            SiteInformationVm model = new SiteInformationVm();
            model.SocailMedia = BiographyMapper.DefulatSocailMedia();
            try
            {
                var settings = await _settingsServices.GetByGroupIdAsync((int)BiogrphyGroupEnum.Information, GetCurrentDataLang());

                return View(settings != null ? settings.MapTOSiteInformationVm() : model);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View(model);
        }
        [HttpPost("{Culture}/[Area]/[Controller]/[Action]")]
        public virtual async Task<IActionResult> Information(SiteInformationVm model, IFormCollection collection)
        {

            bool newLogoUploaded = false;
            string oldLogo = model.Logo;
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.NewLogo != null)
                    {
                        UploadFileInfo _fileInfo = await GenerateFileInfo(model.NewLogo);
                        UploadedFileURL _upload_result = await _uploadManager.UploadFileAsync(_fileInfo, FileTypesEnum.General);
                        if (_upload_result.Success)
                        {
                            model.Logo = _upload_result.URL;
                            newLogoUploaded = true;
                        }
                        else
                        {
                            AddErrorModel(nameof(model.Logo), _localizer["image_uploading_error"]);
                        }
                    }
                    UpdateBiographyModel data = new UpdateBiographyModel
                    {
                        GroupId = (int)BiogrphyGroupEnum.Information,
                        Lang = GetCurrentDataLang(),
                        Biographies = BiographyMapper.MapModelVmToListBiographyModel(model, (int)BiogrphyGroupEnum.Information)
                    };

                    var request = await _settingsServices.EditAsync(data);

                    if (request.Success)
                    {
                        if (newLogoUploaded)
                        {
                            await DeleteFilesAsync(oldLogo);
                        }
                        TempData["UpdateDone"] = true;

                        await _biographiesManager.ReloadInfoAsync();
                        return View(model);
                    }
                    else
                    {
                        if (newLogoUploaded)
                        {
                            await DeleteFilesAsync(model.Logo);
                            model.Logo = oldLogo;
                        }

                        if (request.Messages != null)
                        {
                            AddModelStateError(request.Messages);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View(model);
        }

        [HttpGet("{Culture}/[Area]/[Controller]/[Action]")]
        public virtual async Task<IActionResult> Biography()
        {
            SiteInformationVm model = new SiteInformationVm();
            model.SocailMedia = BiographyMapper.DefulatSocailMedia();
            try
            {
                var settings = await _settingsServices.GetByGroupIdAsync((int)BiogrphyGroupEnum.Biography, GetCurrentDataLang());

                return View(settings != null ? settings.MapTOSiteInformationVm() : model);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View(model);
        }

        [HttpPost("{Culture}/[Area]/[Controller]/[Action]")]
        public virtual async Task<IActionResult> Biography(SiteInformationVm model, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UpdateBiographyModel data = new UpdateBiographyModel
                    {
                        GroupId = (int)BiogrphyGroupEnum.Biography,
                        Lang = GetCurrentDataLang(),
                        Biographies = BiographyMapper.MapModelVmToListBiographyModel(model, (int)BiogrphyGroupEnum.Biography)
                    };

                    var request = await _settingsServices.EditAsync(data);


                    if (request.Success)
                    {
                        TempData["UpdateDone"] = true;
                        await _biographiesManager.ReloadInfoAsync();
                        return View(model);
                    }
                    else
                    {
                        if (request.Messages != null)
                        {
                            AddModelStateError(request.Messages);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View(model);
        }

    }
}
