using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Core.TagHelpers
{
    [HtmlTargetElement("Import")]
    public class File : TagHelper
    {



        //[HtmlAttributeNotBound]
        #region private 
        private const string _baseDirectory = "/UploadFolder/avatars/";
            private const string _empty = "~/portal/img/empty.jpg";
            private readonly IHostingEnvironment _hostingEnvironment;
            private IUrlHelperFactory _urlHelperFactory { get; set; }

        public ViewContext ViewContext { get; set; }
        #endregion



        #region ctor
        public File(IHostingEnvironment hostingEnvironment , IUrlHelperFactory url )
        {
            _hostingEnvironment = hostingEnvironment;
            _urlHelperFactory = url;
          
        }
        #endregion

        #region attributes

        public string ControllerName { get; set; } = "Files";
        public string ActionName { get; set; } = "View";
        public string file { get; set; }

        public bool  inline { get; set; }

        #endregion

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            output.Attributes.Add("src", CreateImage());
          
            output.Content.SetHtmlContent(output);
        }


        private Bitmap CreateImage()
        {
            string imgPath = $"{_hostingEnvironment.WebRootPath}{_baseDirectory}{file}";

            if (System.IO.File.Exists(imgPath))
            {
                try
                {
                    Image image = System.Drawing.Image.FromFile(imgPath);

                    Bitmap outImage = new Bitmap(image);
                    Graphics outGraphics = Graphics.FromImage(outImage);
                    SolidBrush sb = new SolidBrush(System.Drawing.Color.White);

                    outGraphics.FillRectangle(sb, 0, 0, outImage.Width, outImage.Height);
                    outGraphics.DrawImage(image, 0, 0, outImage.Width, outImage.Height);
                    sb.Dispose();
                    outGraphics.Dispose();
                    image.Dispose();

                    Stream newStream = new MemoryStream();
                    outImage.Save(newStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    outImage.Dispose();
                    outGraphics.Dispose();
                    newStream.Seek(0, SeekOrigin.Begin); //go back to start 
                    // new FileStreamResult(newStream, "image/jpeg");
                    return outImage;

                }
                catch (Exception ex)
                {
                  
                }
                return new Bitmap(12,12); 
            }
            return new Bitmap(12, 12);
        }
    }
}



/*
    
        public async Task< IActionResult> View([FromRoute] string img)
        {
             
           
            if ( ) 
            try
            {
                 

                Response.ContentType = "image/jpeg";
                Response.Clear();


                // Create "blank" image for drawing new image
               


                // Fill "blank" with new sized image
                


                
            }

            catch(Exception ex)
            {
               
            }
           
        }

    }
}
     */
