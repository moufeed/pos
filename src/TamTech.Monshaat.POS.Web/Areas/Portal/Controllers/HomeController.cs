using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TamTech.Monshaat.POS.Web.Core.Telemetry;
using System.Linq;
using TamTech.Monshaat.POS.Web.Services.ContentService.Pages;
using TamTech.Monshaat.POS.Web.Services.ContentService.ContactUs.Models;
using TamTech.Monshaat.POS.Web.Services.Email;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sliders;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using TamTech.Monshaat.POS.Web.Services.Upload;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sliders.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Pages.Models;
using TamTech.Monshaat.POS.Web.Models.VMs.Portal.Contactus;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors;
using TamTech.Monshaat.POS.Web.Core.Mappers.Contact;
using TamTech.Monshaat.POS.Web.Models.Dtos.Attachments;
using TamTech.Monshaat.POS.Web.Services.ContentService.ContactUs;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.Services.POSs.Directory;
using TamTech.Monshaat.POS.Web.Services.ContentService.Regions;
using TamTech.Monshaat.POS.Web.Core.Enums;
using System.Web;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;

namespace TamTechSDK.Web.Controllers.Portal
{
   
    public class HomeController : PublicBaseController
    {
        #region prop
        private readonly IPageService _pageService;
        private readonly IEmailSenderService _emailSender;
        private readonly ISliderServices _sliderService;
        private readonly IUploadManagerService _uploadManager;
        private IStringLocalizer<BaseController> _localizer;
        private readonly IPOSSectorServices _sectorService;
        private readonly IContactService _contactService;
        private readonly IContactTypeService _typeService;
        private readonly IDirectoryServices _serchservices;
        private readonly IContactRegionService _regionsServices;

        #endregion
        public HomeController(ITelemetryService telemetryClientService,
                                    IPageService pageService,
                                    ISliderServices slidersServices,
                                    IUploadManagerService uploadManager,
                                    IStringLocalizer<BaseController> localizer,
                                    IPOSSectorServices sectorService,
                                    IContactService contactService,
                                    IContactTypeService typeService,
                                    IDirectoryServices serchservices,
                                    IContactRegionService regionsServices
                                    ) : base(telemetryClientService ,localizer)
        {
            _pageService = pageService;
            _sliderService = slidersServices;
            _uploadManager = uploadManager;
            _localizer = localizer;
            _sectorService = sectorService;
            _contactService = contactService;
            _typeService = typeService;
            _serchservices = serchservices;
            _regionsServices = regionsServices;
        }

        #region Utilities

        private async Task<IActionResult> GetSectionPage(int settingId)
        {
            try
            {
                var page = await _pageService.GetPublishedSectionsBySettingIdAsync(settingId);
                if (VerifySucceed(page))
                {
                    return View("SectionsPage", page.Data);
                }

            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("SectionsPage");
        }

        #endregion


        [HttpGet]
        public virtual async Task<IActionResult> Index([FromQuery]string access_token, [FromQuery]string returnUrl)
        {
            if (!string.IsNullOrWhiteSpace(access_token))
            {
                return RedirectToAction(TamTech.Monshaat.POS.EFile2.Utilities.Constants.IndexAction,
                                        TamTech.Monshaat.POS.EFile2.Utilities.Constants.OAuthController, new { access_token, returnUrl });
            }

            // ViewBag.Host = _appSettingsService.GetURl();
            try
            {
                // slider
                IRequestProviderResult<SliderDto> publicMainSlider = await _sliderService.GetPublishedBySettingIdAsync((int)SettingKeysEnum.HomePageMainSlider);
                if (VerifySucceed(publicMainSlider))
                {
                    ViewBag.publicMainSlider = publicMainSlider.Data;
                }

                // sectors
                var _sectors = await _sectorService.GetPublishedListAsync();
                if (VerifySucceed(_sectors))
                {
                    ViewBag.sectors = _sectors.Data;
                }

                var _total = await _serchservices.GetCountOfPublishedAsync(_lang);
                if (VerifySucceed(_total))
                {
                    ViewBag.TotalCount = _total.Data;
                }

                //  Benefits

                IRequestProviderResult<HtmlPage> Benefits = await _pageService.GetPublishedHtmlBySettingIdAsync((int)SettingKeysEnum.HomePageSummary1);

                if (VerifySucceed(Benefits))
                {
                    ViewBag.Benefitssummary = Benefits.Data;
                }


                // about this initiative
                IRequestProviderResult<HtmlPage> initiative_Summary = await _pageService.GetPublishedHtmlBySettingIdAsync((int)SettingKeysEnum.HomePageSummary2);

                if (VerifySucceed(initiative_Summary))
                {
                    ViewBag.initiativeSummary = initiative_Summary.Data;
                }

            }
            catch (Exception ex)
            {
                TrackException(ex);
            }


            return View();
        }

        #region Contact Us
        [HttpGet]
        public virtual async Task<IActionResult> ContactUs()
        {
            ContactusVM model = new ContactusVM();
            try
            {
                var types = await _typeService.GetPublishedListAsync();
                ViewBag.types =  VerifySucceed(types) ? types.Data : new List<TypeDto>();
                var Regions = await _regionsServices.GetPublishedSelectListAsync(_lang);
                var _regionsdata = VerifySucceed(Regions) ? Regions.Data : new List<SelectListItemModel>();
                ViewBag.Regions = new SelectList(_regionsdata, "Value", "Text");
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View(model);
        }


        [HttpPost]
 
        public virtual async Task<IActionResult> ContactUs(ContactusVM model, IFormCollection collection)
        {


            List<AttachmentModel> Attachments = new List<AttachmentModel>();
            bool PreviousUploadFiles = collection.ContainsKey("UploadedFiles");
            var _UploadedFiles = "";
            int UpCount = 0;
            try
            {
                if (ModelState.IsValid)
                {
                     
                    CreateModel _CreateModel = model.MapToCreateModelWithoutAttachments();
                    if (PreviousUploadFiles)
                    {
                        string urlstring = collection["UploadedFiles"];
                        if (urlstring.Length > 0)
                        {
                            List<string> Urls = urlstring.Split(";;").ToList();
                            Urls.RemoveAt(Urls.Count - 1);  // remove an empty item  
                            foreach (var url in Urls)
                            {
                                Attachments.Add(MakeAttachment(url));
                            }
                        }
                    }
                    if (model.Attachments != null && model.Attachments.Count > 0)
                    {
                        int index = 0;
                        List<IFormFile> _files = model.Attachments;
                        var filesInfo = await GenerateListFilesInfo(_files, FileTypesEnum.ContactUsFile);
                        var uploadResult = await _uploadManager.UploadListFilesAsync(filesInfo);

                        if (uploadResult.Success)
                        {
                            foreach (var item in uploadResult.Data.URLs)
                            {

                                if (item.Success)
                                {
                                    Attachments.Add(MakeAttachment(item.URL));
                                    _UploadedFiles += $"{item.URL};;";
                                    UpCount++;
                                }
                                else
                                {
                                    ModelState.AddModelError(_files[index].Name, _localizer["felled_uploading_error", _files[index].FileName]);
                                }

                                index++;
                            }
                        }
                        HandelResult(uploadResult);

                        if (!TryValidateModel(model))
                        {
                            // todo show uploded files in portal
                            ViewBag.UploadedFiles = _UploadedFiles;
                            ViewBag.UploadedCount = UpCount;
                            return View(model);
                        }

                        _CreateModel.Attachments = Attachments;

                    }


                    var sendRequest = await _contactService.CreateAsync(_CreateModel);
                    
                    if (sendRequest.Success)
                    {
                        TempData["ContactSuccess"] = true;
                        return Redirect("success");
                    }
                    else
                    {
                        HandelResult(sendRequest);
                        ViewBag.UploadedFiles = _UploadedFiles;
                        TryValidateModel(model);
                         
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            var types = await _typeService.GetPublishedListAsync();
            ViewBag.types = VerifySucceed(types) ? types.Data : new List<TypeDto>();
            return View(model);

        }
        #endregion


        
       

        public virtual async Task<IActionResult> PrivacyPolicy() => await GetSectionPage((int)SettingKeysEnum.PrivacyPolicy);

        public virtual async Task<IActionResult> TermsofUse() => await GetSectionPage((int)SettingKeysEnum.TermsofUse);
         
        public virtual IActionResult Success() => View("/Areas/Portal/Views/Shared/Success.cshtml");
    }
}
