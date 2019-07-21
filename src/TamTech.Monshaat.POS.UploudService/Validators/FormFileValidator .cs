using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Http;   
using System.IO;       
using TamTech.Monshaat.POS.UploadService.Settings;

namespace TamTech.Monshaat.POS.UploadService.Validators
{
    public class FormFileValidator : AbstractValidator<IFormFile>
    {
        public FormFileValidator(FileTypeSettings settings)
        {
             
            RuleFor(f=> f).Custom((file, context) =>
            { 
                context = new FileValidation().ValidateFile(file, settings, context); 
            });
        }  
    }

    public class FileValidation  
    {
        public CustomContext ValidateFile(IFormFile file, FileTypeSettings settings, CustomContext context)
        {
            if (file == null)
            {
                context.AddFailure("file is not uploaded successfully");
                return context;
            }

            if (file.Length > settings.MaxSize)
            {
                context.AddFailure($"{file.FileName} file size is greater than the allowed max size");
            }

            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            if (!settings.GetAllowedExtensions().Contains(fileExtension))
            {
                context.AddFailure($"{file.FileName} is not allowed file type.");
            }

            return context;
        }
    }
}
