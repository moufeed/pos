using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;     
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Attachments;       
using TamTech.Monshaat.POS.Web.SDK.Services.Upload;
using TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models;  
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TamTechSDK.Web.Controllers.Portal
{

    [Area("Portal")]
    public abstract class PublicBaseController : BaseController
    {


        public static int HtmlRenderCounter = 0;
        public readonly ILogger _logger;
        public readonly string _lang;
        public readonly string _culture;


        public PublicBaseController(ITelemetryService telemetryClientService ,
            ILogger<PublicBaseController> logger,
            IStringLocalizer<BaseController> localizer)
          : base(telemetryClientService, localizer)
        {

            _lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            _culture = CultureInfo.CurrentCulture.Name;
            HtmlRenderCounter = 1;
            _logger = logger;

       }


        public  void TrackException(Exception ex, params object[] args)
        {
            try
            {
                string msg = "params";

                if (args != null)
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        msg += "{" + i + "},";
                    }


                    object[] newArgs = new object[args.Length];
                    for (int i = 0; i < args.Length; i++)
                    {
                        if (args[i] != null)
                        {
                            var ser = JsonConvert.SerializeObject(args[i]);
                            var json = JsonConvert.DeserializeObject(ser);
                            newArgs[i] = json;
                        }
                    }
                    args = newArgs;
                }

                _logger.LogWarning(2, ex, msg, args);
            }
            catch  (Exception exc)
            {
                _logger.LogWarning(2,  ex,"");
            }

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
                    ContentType = file.ContentType,
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
            string _url = (URl.Contains("http://") || URl.Contains("https://")) ? URl : $"https://localhost/" + URl ;


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




    }
}