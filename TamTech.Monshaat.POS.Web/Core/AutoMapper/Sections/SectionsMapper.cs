using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.ContentService.Sections.Models;
using TamTechSDK.Web.Models.Admin.Sections;

namespace TamTechSDK.Web.Extensions.AutoMapper.Sections
{
    public static class SectionsMapper
    {
        public static SectionFormVM MapDtoToVM(this SectionDto dto)
        {
            return new SectionFormVM
            {
                Id = dto.Id,
                Title = dto.Title,
                Slug = dto.Slug,
                ParentId = dto.ParentId,
                Summary = dto.Summary,
                MainImage = dto.MainImage,
                DisplayOrder = dto.DisplayOrder,
                Lang = dto.Lang,
                MetaDescription = dto.MetaDescription,
                SEOMarkup = dto.SEOMarkup,
                PublishedDate = dto.PublishedDate,
                ModifiedDate = dto.ModifiedDate,
                Locked = dto.Locked,
                Published = dto.Published
            };
        }

        public static SectionDto VMToDto(this SectionFormVM vm)
        {
            return new SectionDto
            {
                Id = vm.Id,
                Title = vm.Title,
                Slug = vm.Slug,
                ParentId = vm.ParentId,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                DisplayOrder = vm.DisplayOrder,
                Lang = vm.Lang,
                MetaDescription = vm.MetaDescription,
                SEOMarkup = vm.SEOMarkup,
                PublishedDate = vm.PublishedDate,
                ModifiedDate = vm.ModifiedDate
            };
        }

        public static CreateSectionDto MapToCreateDto(this SectionFormVM vm)
        {
            return new CreateSectionDto
            {
                Title = vm.Title,
                Slug = vm.Slug,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                ParentId = vm.ParentId,
                DisplayOrder = vm.DisplayOrder,
                Lang = vm.Lang,
                MetaDescription = vm.MetaDescription,

            };
        }

        public static UpdateSectionDto MapToUpdateDto(this SectionFormVM vm)
        {
            return new UpdateSectionDto
            {
                Id = vm.Id,
                Title = vm.Title,
                Slug = vm.Slug,
                ParentId = vm.ParentId,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                DisplayOrder = vm.DisplayOrder,
                Lang = vm.Lang,
                MetaDescription = vm.MetaDescription,
                SEOMarkup = vm.SEOMarkup,
                PublishedDate = vm.PublishedDate,
                ModifiedDate = vm.ModifiedDate
            };
        }
    }
}
