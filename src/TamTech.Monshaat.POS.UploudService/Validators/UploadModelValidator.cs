using FluentValidation;
using System.IO;
using System.Linq;
using TamTech.Monshaat.POS.UploadService.Models;
using TamTech.Monshaat.POS.UploadService.Configurations;
using TamTech.Monshaat.POS.UploadService.Settings;

namespace TamTech.Monshaat.POS.UploadService.Validators
{
    public class UploadModelValidator : AbstractValidator<UploadModel>
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
        public UploadModelValidator(FileTypeSettings settings)
        {
            RuleFor(files => files).NotNull();
            RuleFor(files => files.UploadFiles).NotNull();
            RuleFor(files => files.UploadFiles.Count).GreaterThan(0);

            this.When(x => LanguageEnum.EN == lang && !x.Published_en, () =>
            {
                RuleFor(x => x.Title_en).Must(x => !string.IsNullOrWhiteSpace(x)).WithName("Could not publish").WithMessage("Can not publish when the item does not have an Title");//The MainImage field is required

            });
            RuleFor(files => files).Custom((files, context) =>
            {
                foreach (var file in files)
                {
                    context = new FileValidation().ValidateFile(file, settings, context);
                }
            });


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
