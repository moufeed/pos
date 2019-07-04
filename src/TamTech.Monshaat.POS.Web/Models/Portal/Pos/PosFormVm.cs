using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TamTechSDK.Common.Services.Attributes.Models;

namespace TamTechSDK.Web.Models.Portal.Pos
{



    public class PosFormVm
    {

        public Guid Id { get; set; }

        [Required]
        public String Name { get; set; }

        public String Lang { get; set; }

        public int TypeId { get; set; }


        public String Description { get; set; }

        public List<IFormFile> Attachments { get; set; }

        public int? SectorId { get; set; }

        public string OtherSector { get; set; }

        // public Dictionary<int, Dictionary<int, bool>> Specifications { get; set; }

        public List<Specification> Specifications { get; set; }
        public List<Specification> SpecificationsB { get; set; }


        public Guid VendorId { get; set; }

        [Required]
        public string About { get; set; }

        public double Price { get; set; }

        public string Slug { get; set; }

        public string Tags { get; set; }

        public bool Published { get; set; }

        public int DisplayOrder { get; set; }

        public string GenericField { get; set; }

        public List<string> TempImages { get; set; }

        public int StatusId { get; set; }
    }


    public class Specification
    {

        public int Id { get; set; }

        public int ChoiceType { get; set; }

        public int InputType { get; set; }

        public List<value> Values { get; set; }
    }


    public class value
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsChecked { get; set; }
    }
    public class PosFormVmValidator : AbstractValidator<PosFormVm>
    {
        public PosFormVmValidator(IStringLocalizer<PosFormVm> localizer)
        {
            this.When(x => x.SectorId == null && string.IsNullOrWhiteSpace(x.OtherSector), () =>
           {
               RuleFor(x => x.OtherSector).Must(x => !string.IsNullOrWhiteSpace(x)).OverridePropertyName("OtherSector").WithMessage(localizer["sector_validate"]);
           });

        }
    }
}



