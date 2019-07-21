using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;
using TamTech.Monshaat.POS.Web.SDK.Services.Upload;
using TamTech.Monshaat.POS.Web.SDK.Services.Upload.FileTypes;

namespace TamTech.Monshaat.POS.Web.Areas.Shared.Controllers
{
    public class FilesController : Controller
    {

    //    public const string ControllerName = "Files";
    //    public const string ImgAction = "View";
        public const string _empty = "~/portal/img/empty.jpg";
        public const string _uploadDirectoary = "UploadFolder";
        public readonly IHostingEnvironment _hostingEnvironment;
        List<FileTypesSettingsModel> _fileTypesSettings;
  

        public FilesController(IHostingEnvironment hostingEnvironment , IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
             
            _fileTypesSettings = configuration.GetSection(AppSettings.WebApplicationSettings)
                                .GetSection(AppSettings.WebApplication_FilesTypesSettings)
                                .GetSection(AppSettings.FilesTypes)
                                .Get<List<FileTypesSettingsModel>>();
        }

      

        #region utilities



         

      



        [NonAction]
        private string GetType(string TypeName)
        {
            FileTypesSettingsModel model = _fileTypesSettings.FirstOrDefault(setting => setting.File.Equals(TypeName, System.StringComparison.OrdinalIgnoreCase));
            if (model != null && model != default(FileTypesSettingsModel))
            {
                return model.Type;
            }
            else
            {
                FileTypesSettingsModel generalmodel = _fileTypesSettings.FirstOrDefault(setting => setting.File.Equals(FileTypesEnum.General.ToString(), System.StringComparison.OrdinalIgnoreCase));
                if (generalmodel != null && generalmodel != default(FileTypesSettingsModel))
                {
                    return model.Type;
                }
                else
                {
                    return "avatars";
                }
            }

        }

       
     
        private ImageFormat GetFormat(string _extension)
        {
            switch (_extension)
            {
                case ".bmp":
                    return ImageFormat.Bmp;

                case ".gif":
                    return ImageFormat.Gif;

                case ".ico":
                    return ImageFormat.Icon;

                case ".png":
                    return ImageFormat.Png;

                default:
                    return ImageFormat.Jpeg;
            }
        }


        private bool FileIsImage(string contenttype)
        {
            return 
           string.Equals(contenttype, "image/jpg", StringComparison.OrdinalIgnoreCase) ||
           string.Equals(contenttype, "image/jpeg", StringComparison.OrdinalIgnoreCase) ||
           string.Equals(contenttype, "image/pjpeg", StringComparison.OrdinalIgnoreCase) ||
           string.Equals(contenttype, "image/gif", StringComparison.OrdinalIgnoreCase) ||
           string.Equals(contenttype, "image/x-png", StringComparison.OrdinalIgnoreCase) ||
           string.Equals(contenttype, "image/png", StringComparison.OrdinalIgnoreCase) ||
           string.Equals(contenttype, "image/webp", StringComparison.OrdinalIgnoreCase) ||
           string.Equals(contenttype, "image/x-icon", StringComparison.OrdinalIgnoreCase) ;
        }
        #endregion


        [HttpGet("[Controller]/[Action]/{type}/{img}")]
        public async Task<IActionResult> View([FromRoute] string img, string type )
        {
            string _contenttype ="";
            string _FileName = img;
            string _baseDirectory = GetType(type);
            string _filePath = $"{ _hostingEnvironment.WebRootPath}/{_uploadDirectoary}/{_baseDirectory}/{_FileName}";
            string _extension = System.IO.Path.GetExtension(_filePath);

            if (System.IO.File.Exists(_filePath))
            {
                try
                {
                    FileExtensionContentTypeProvider mimeType = new FileExtensionContentTypeProvider();
                    bool _hasType = mimeType.TryGetContentType(_FileName , out _contenttype );
                    if (_hasType  && _contenttype != "application/octet-stream")
                    {
                        Response.ContentType =   _contenttype;
                    }

                    FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
                    return base.File(fs, _hasType ? _contenttype : "application/octet-stream");


                    //if (FileIsImage(_contenttype))
                    //{
                    //    Image image = Image.FromFile(_filePath);
                    //    Bitmap outImage = new Bitmap(image);
                    //    Graphics outGraphics = Graphics.FromImage(outImage);
                    //    outGraphics.CompositingQuality = CompositingQuality.HighSpeed;
                    //    outGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    //    outGraphics.CompositingMode = CompositingMode.SourceCopy;
                    //    outGraphics.DrawImage(image, 0, 0, outImage.Width, outImage.Height);
                    //    outGraphics.Dispose();
                    //    image.Dispose();
                    //    Stream newStream = new MemoryStream();
                    //    outImage.Save(newStream, GetFormat(_extension.ToLower()));
                    //    outImage.Dispose();
                    //    outGraphics.Dispose();
                    //    newStream.Seek(0, SeekOrigin.Begin);
                    //    return base.File(newStream, _hasType ? _contenttype : "application/octet-stream");
                    //}
                    //else
                    //{

                    //}


                }
                catch (Exception ex)
                { }

            }
            return base.File(_empty, "image/jpg");

        }

       
    }
}