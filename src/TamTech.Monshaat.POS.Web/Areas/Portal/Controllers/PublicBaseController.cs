using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Models.Attachments;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Menus.Enums;
using TamTechSDK.Common.Services.ContentService.Menus.Models;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Common.Services.Upload.Models;
using TamTechSDK.Web.Filters;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Portal
{

    [Area("Portal")]
    public abstract class PublicBaseController : BaseController
    {



        public readonly string _lang;
        public readonly string _culture;


        public PublicBaseController(ITelemetryClientService telemetryClientService)
             : base(telemetryClientService)
        {

            _lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            _culture = CultureInfo.CurrentCulture.Name;

        }





        public void TrackIfNotFilesDeleted(bool success,
                                           HttpStatusCode statusCode,
                                           DeleteFilesModelResult resultModel,
                                           dynamic inputModel)
        {
            if (success)
            {
                var errorlist = resultModel.Results.Where(item => item.Result == DeleteResult.NotDeleted);
                if (errorlist != null && errorlist.Count() > 0)
                {
                    TrackEvent("TrackIfNotFilesDeleted_Result", errorlist);
                }
            }
            else
            {
                TrackEvent("TrackIfNotFilesDeleted_Input", inputModel, statusCode.ToString());
            }
        }


        public async Task<UploadFileInfo> GenerateFileInfo(IFormFile file)
        {
            MemoryStream stream = new MemoryStream();
            await file.CopyToAsync(stream);
            stream.Position = 0;
            return new UploadFileInfo
            {
                Stream = stream,
                FileName = file.FileName
            };
        }


        public async Task<List<UploadFileModel>> GenerateListFilesInfo(List<IFormFile> files, FileTypesEnum type)
        {
            List<UploadFileModel> Files = new List<UploadFileModel>();
            foreach (var file in files)
            {
                Files.Add(new UploadFileModel
                {
                    Type = type,
                    FileInfo = await GenerateFileInfo(file)
                });
            }
            return Files;
        }


        public void AddModelStateError(Dictionary<string, List<string>> messages)
        {
            foreach (var res in messages)
            {
                foreach (var msg in res.Value)
                {
                    ModelState.AddModelError(res.Key, msg);
                }
            }
        }


        public AttachmentModel MakeAttachment(string URl)
        {

            string _Filename;
            string _Extension;
            string _path;
            string _localURl;
            string _url = (URl.Contains("http://") || URl.Contains("https://")) ? URl : $"https://localhost{URl}";


            Uri uri = new Uri(_url);
            var filename = uri.Segments.Last();
            _Filename = Path.GetFileNameWithoutExtension(filename);
            _Extension = Path.GetExtension(filename);
            _localURl = uri.PathAndQuery;
            var seg = uri.Segments.ToList();
            seg.RemoveAt(seg.Count - 1);
            _path = string.Join("", seg);

            AttachmentModel Attachment = new AttachmentModel()
            {
                Name = _Filename,
                FullUrl = _localURl,
                Path = _path,
                Extension = _Extension
            };
            return Attachment;
        }




        /* private List<MenuItemDto> _sortMenu(List<MenuItemDto> Menus) {
             var menu = new List<MenuItemDto>();
             if (Menus?.Count > 0) {
                 menu = Menus.OrderBy(m => m.DisplayOrder).ToList();
                 foreach (var Menu in Menus)
                 {
                     if (Menu.MenuItems?.Count > 0)
                     {
                         Menu.MenuItems = _sortMenu(Menu.MenuItems);
                     }
                 }
                 return menu;
             }
             return menu;
         }  */

    }
}