using FluentValidation;       
using Microsoft.AspNetCore.Http;
using System.Collections.Generic; 
using TamTech.Monshaat.POS.UploadService.Settings;

namespace TamTech.Monshaat.POS.UploadService.Validators
{
    public class FormFilesValidator : AbstractValidator<List<IFormFile>>
    {
        public FormFilesValidator(FileTypeSettings settings)
        {
            RuleFor(files => files).NotNull();
            RuleFor(files => files.Count).GreaterThan(0);

            RuleFor(files => files).Custom((files, context) =>
            {
                foreach (var file in files)
                {
                    context = new FileValidation().ValidateFile(file, settings, context);
                }
            });
        } 
    }



}
