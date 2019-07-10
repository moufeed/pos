using FluentValidation;
using System.IO;
using System.Linq;
using TamTech.Monshaat.POS.UploadService.Models;
using TamTech.Monshaat.POS.UploadService.Configurations;
using TamTech.Monshaat.POS.UploadService.Settings;
using FluentValidation.Validators;
using Microsoft.AspNetCore.StaticFiles;
using System;

namespace TamTech.Monshaat.POS.UploadService.Validators
{
    public class UploadModelValidator : AbstractValidator<UploadModel>
    {
      
        public UploadModelValidator(FileTypeSettings[] settings)
        {
            RuleFor(files => files).NotNull();
            RuleFor(files => files.UploadFiles).NotNull();
            RuleFor(files => files.UploadFiles.Count).GreaterThan(0);

            this.When(x => x.UploadFiles != null && x.UploadFiles != null  && x.UploadFiles.Count > 0   , () =>
            {
                RuleFor(model => model).Custom((model, context) =>
                {
                   var sett  =  settings.FirstOrDefault(s => s.Type == model.UploadFiles[0].Type);

                    foreach (var file in model.UploadFiles)
                    {
                        context = new UploadFileValidation().ValidateFile(file, sett, context);
                    }
                });

            });    
        
        }
        public class UploadFileValidation
        {
            public CustomContext ValidateFile(UploadFileModel file, FileTypeSettings settings, CustomContext context)
            {  
                if (file.Stream == null)
                {
                    context.AddFailure("حدث خطأ اثناء تحميل الملف");
                    return context;
                }

                if (file.Stream.Length > settings.MaxSize)
                {
                    context.AddFailure($"{file.FileName} حجم الملف أكبر من الحد المسموح به - {settings.MaxSize/ 1024}");
                }

                var fileExtension = Path.GetExtension(file.FileName).ToLower();

                if (!settings.GetAllowedExtensions().Contains(fileExtension))
                {
                    context.AddFailure($"{file.FileName} نوع الملف غير مسموح تحميله");
                }
                else
                {
                    string contentType;
                    var mapping = new FileExtensionContentTypeProvider().Mappings.TryGetValue(".jpg", out contentType);
                    if(!mapping)
                    {
                        context.AddFailure($"{file.FileName} نوع محتوى الملف غير مسموح تحميله");
                    }

                }
            //  var contenttype =    MimeTypes.ScanFileForMimeType(file.Stream);

                if (!settings.GetAllowedExtensions().Contains(fileExtension))
                {
                    context.AddFailure($"{file.FileName} is not allowed file type.");
                }
                return context;
            }
        }

        public string GetExtension(string fileName)
        {
            return Path.GetExtension(fileName).ToLower();
        }

     
    }
}
