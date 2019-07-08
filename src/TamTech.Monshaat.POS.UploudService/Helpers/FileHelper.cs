using System;
using System.Drawing;
using System.IO;
using TamTech.Monshaat.POS.UploadService.Constants;

namespace TamTech.Monshaat.POS.UploadService.Helpers
{
   public class FileHelper
    {
        public string GenerateFileName(string systemPrefix, string filePrefix, string transactionId, string extension)
        {
            systemPrefix = string.IsNullOrEmpty(systemPrefix) ? "" : $"{systemPrefix}_";

            filePrefix = string.IsNullOrEmpty(filePrefix) ? "" : $"{filePrefix}_";

            return $"{systemPrefix}{filePrefix}{transactionId}_{Guid.NewGuid().ToString()}{extension}";
        }

        public string FormatThumbnailFileName(string fileName, string thumbPrefix,bool thumbPrefixIsRequered)
        { 
            return   $"{FormatThumbnailPrefix(thumbPrefix, thumbPrefixIsRequered)}{fileName}";
        }

        public string FormatThumbnailPrefix(  string thumbPrefix, bool thumbPrefixIsRequered)
        { 
            var cons = thumbPrefixIsRequered ? UploadConstants.ThumbnailPrefix : "";
             thumbPrefix = string.IsNullOrWhiteSpace(thumbPrefix) ? cons : $"{thumbPrefix}";
            thumbPrefix = thumbPrefix.Trim('_');
            thumbPrefix += string.IsNullOrWhiteSpace(thumbPrefix)? "": "_";
            return thumbPrefix; 
        }


        public Stream ResizeImage(Stream stream, double maxHeight, double maxWidth)
        {

            Image image = Image.FromStream(stream);
            float ratio;

            // Get height and width of current image
            int width = (int)image.Width;
            int height = (int)image.Height;

            // Ratio and conversion for new size
            if (width > maxWidth)
            {
                ratio = (float)width / (float)maxWidth;
                width = (int)(width / ratio);
                height = (int)(height / ratio);
            }

            // Ratio and conversion for new size
            if (height > maxHeight)
            {
                ratio = (float)height / (float)maxHeight;
                height = (int)(height / ratio);
                width = (int)(width / ratio);
            }

            // Create "blank" image for drawing new image
            Bitmap outImage = new Bitmap(width, height);
            Graphics outGraphics = Graphics.FromImage(outImage);
            SolidBrush sb = new SolidBrush(System.Drawing.Color.White);


            // Fill "blank" with new sized image
            outGraphics.FillRectangle(sb, 0, 0, outImage.Width, outImage.Height);
            outGraphics.DrawImage(image, 0, 0, outImage.Width, outImage.Height);
            sb.Dispose();
            outGraphics.Dispose();
            image.Dispose();

            // Save new image as jpg
            Stream newStream = new MemoryStream();
           outImage.Save(newStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            outImage.Dispose();
            outGraphics.Dispose();
            newStream.Seek(0, SeekOrigin.Begin); //go back to start 
            return newStream;



        }

    }
}
