using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Areas.Portal.Controllers
{

    public class FilesController : Controller
    {
        public const string ImgCtrl = "Files";
        public const string ImgAction = "View"; 

        private const string _baseDirectory = "~/UploadFolder/avatars";
        private const string _empty = "~/portal/img/pos-empty.jpg";


        //public IActionResult Index()
        //{

        //    return View();
        //}

        [HttpGet("[Controller]/[Action]/img")]
        public async Task< IActionResult> View([FromRoute] string img)
        {

            if (!System.IO.File.Exists(img))
                return base.File(_empty, "image/jpg");
            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(img); 

                Response.ContentType = "image/jpeg";
                Response.Clear();


                // Create "blank" image for drawing new image
                Bitmap outImage = new Bitmap(image);
                Graphics outGraphics = Graphics.FromImage(outImage);
                SolidBrush sb = new SolidBrush(System.Drawing.Color.White);


                // Fill "blank" with new sized image
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

                return base.File(newStream, "image/jpeg");
            }

            catch
            {
                return base.File(_empty, "image/jpg");
            }
        }

    }
}