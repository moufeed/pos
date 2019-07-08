using FluentValidation; 
using System.IO;
using System.Linq;
using TamTech.CasAuctions.TamTech.Monshaat.POS.UploadService.Models;
using TamTech.Monshaat.POS.UploadService.Configurations;
using TamTech.Monshaat.POS.UploadService.Settings;

namespace TamTech.Monshaat.POS.UploadService.Validators
{
    public class UploadModelValidator : AbstractValidator<UploadModelDTO>
    {
        public UploadModelValidator(IUploadSettingsConfigurations appSettings)
        {
            FileTypeSettings[] settings = appSettings.GetFileTypeSettings();

            RuleFor(uploadModel => uploadModel.UploadFiles).NotNull();
            RuleFor(uploadModel => uploadModel.UploadFiles.Count).GreaterThan(0);

            RuleFor(uploadModel => uploadModel).Custom((uploadModel, context) =>
            {
                foreach (var file in uploadModel.UploadFiles)
                {
                    var validationsFromSettings = settings.Where(s => s.Type == file.Type).SingleOrDefault();
                    if (validationsFromSettings == null)
                    {
                        context.AddFailure($"{file.Type} file type is not allowed");
                        continue;
                    }

                    if (file.FileBinary == null)
                    {
                        context.AddFailure($"{file.Type} file type is not uploaded successfully");
                        continue;
                    }

                    if (file.FileBinary.Length > validationsFromSettings.MaxSize)
                    {
                        context.AddFailure($"{file.FileBinary.FileName} file size is greater than the allowed max size");
                    }

                    var fileExtension = GetExtension(file.FileBinary.FileName);

                    if (!validationsFromSettings.GetAllowedExtensions().Contains(fileExtension))
                    {
                        context.AddFailure($"{file.FileBinary.FileName} is not allowed file type.");
                    }

                }
            }

            );
        }

        public string GetExtension(string fileName)
        {
            return Path.GetExtension(fileName).ToLower();
        }
    }
}
