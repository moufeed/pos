using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TamTech.Monshaat.POS.Web.Core.Telemetry;
using System.Linq;
using TamTech.Monshaat.POS.Web.Services.ContentService.Pages;
using TamTech.Monshaat.POS.Web.Services.ContentService.Contact.Models;
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
using TamTech.Monshaat.POS.Web.Services.PosService.Sectors;
using TamTech.Monshaat.POS.Web.Core.Mappers.Contact;
using TamTech.Monshaat.POS.Web.Models.Dtos.Attachments;
using TamTech.Monshaat.POS.Web.Services.ContentService.Contact;
using TamTech.Monshaat.POS.Web.Services.TypesService;
using TamTech.Monshaat.POS.Web.Services.PosService.Directory;
using TamTech.Monshaat.POS.Web.Services.Regions;
using TamTech.Monshaat.POS.Web.Core.Enums;

namespace TamTechSDK.Web.Controllers.Portal
{
    public class HomeController : PublicBaseController
    {
        #region prop
        private readonly IPageService _pageService;
        private readonly IEmailSenderService _emailSender;
        private readonly ISlidersServices _sliderService;
        private readonly IUploadManagerService _uploadManager;
        private IStringLocalizer<PublicBaseController> _localizer;
        private readonly ISectorServices _sectorService;
        private readonly IContactService _contactService;
        private readonly IContactTypeService _typeService;
        private readonly IDirectoryServices _serchservices;
        private readonly IRegionService _regionsServices;

        #endregion
        public HomeController(ITelemetryService telemetryClientService,
                                    IPageService pageService,
                                    ISlidersServices slidersServices,
                                    IUploadManagerService uploadManager,
                                    IStringLocalizer<PublicBaseController> localizer,
                                    ISectorServices sectorService,
                                    IContactService contactService,
                                    IContactTypeService typeService,
                                    IDirectoryServices serchservices,
                                    IRegionService regionsServices
                                    ) : base(telemetryClientService)
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
                if (page != null && page.Success)
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
                if (publicMainSlider != null && publicMainSlider.Success)
                {
                    ViewBag.publicMainSlider = publicMainSlider.Data;
                }

                // sectors
                ViewBag.sectors = await _sectorService.GetPublishedListAsync();
                ViewBag.TotalCount = await _serchservices.GetCountOfPublishedAsync(_lang);

                //  Benefits

                IRequestProviderResult<HtmlPage> Benefits = await _pageService.GetPublishedHtmlBySettingIdAsync((int)SettingKeysEnum.HomePageSummary1);

                if (Benefits != null && Benefits.Success)
                {
                    ViewBag.Benefitssummary = Benefits.Data;
                }


                // about this initiative
                IRequestProviderResult<HtmlPage> initiative_Summary = await _pageService.GetPublishedHtmlBySettingIdAsync((int)SettingKeysEnum.HomePageSummary2);

                if (initiative_Summary != null && initiative_Summary.Success)
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
                ViewBag.types = types;
                //  ViewBag.Host = _appSettingsService.GetURl();
                var Regions = await _regionsServices.GetPublishedSelectListAsync(_lang);
                ViewBag.Regions = new SelectList(Regions, "Value", "Text");
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
                        var filesInfo = await GenerateListFilesInfo(_files, FileTypesEnum.General);
                        var uploadResult = await _uploadManager.UploadListFilesAsync(filesInfo);

                        foreach (var item in uploadResult.URLs)
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
                        if (sendRequest.Messages.Count > 0)
                        {
                            AddModelStateError(sendRequest.Messages);
                            ViewBag.UploadedFiles = _UploadedFiles;
                            TryValidateModel(model);
                            return View(model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }


            var types = await _typeService.GetPublishedListAsync();
            ViewBag.types = types;

            return View(model);

        }
        #endregion


        public virtual async Task<IActionResult> Success()
        {
            return View("/Areas/Portal/Views/Shared/Success.cshtml");
        }

        public virtual async Task<IActionResult> PrivacyPolicy()
        {
            return await GetSectionPage((int)SettingKeysEnum.PrivacyPolicy);
        }
        public virtual async Task<IActionResult> TermsofUse()
        {
            return await GetSectionPage((int)SettingKeysEnum.TermsofUse);
        }
    }
}
