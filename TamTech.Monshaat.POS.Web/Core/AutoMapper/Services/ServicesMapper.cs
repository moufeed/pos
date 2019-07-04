using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.ContentService.Services.Models;
using TamTechSDK.Web.Models.Admin.Services;

namespace TamTechSDK.Web.Extensions.AutoMapper.Services
{
    public static class PostMapper
    {


        public static ServiceFormVM MapDtoToVM(this ServiceDto dto)
        {
            return new ServiceFormVM
            {
                Id = dto.Id,
                Title = dto.Title,
                Slug = dto.Slug,
                Content = dto.Content,
                Summary = dto.Summary,
                MainImage = dto.MainImage,
                Section = dto.Section,
                DisplayOrder = dto.DisplayOrder,
                Lang = dto.Lang,
                Icon = dto.Icon,
                IconVisibility = dto.IconVisibility,
                MetaDescription = dto.MetaDescription,
                SEOMarkup = dto.SEOMarkup,
                PublishedDate = dto.PublishedDate,
                ModifiedDate = dto.ModifiedDate,
                Locked = dto.Locked,
                Published = dto.Published
            };
        }

        public static ServiceDto VMToDto(this ServiceFormVM vm)
        {
            return new ServiceDto
            {
                Id = vm.Id,
                Title = vm.Title,
                Slug = vm.Slug,
                Content = vm.Content,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                Section = vm.Section,
                DisplayOrder = vm.DisplayOrder,
                Lang = vm.Lang,
                Icon = vm.Icon,
                IconVisibility = vm.IconVisibility,
                MetaDescription = vm.MetaDescription,
                SEOMarkup = vm.SEOMarkup,
                PublishedDate = vm.PublishedDate,
                ModifiedDate = vm.ModifiedDate
            };
        }

        public static CreateServiceDto MapFormVMToCreateDto(this ServiceFormVM vm)
        {
            return new CreateServiceDto
            {
                Title = vm.Title,
                Slug = vm.Slug,
                Content = vm.Content,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                Section = vm.Section,
                DisplayOrder = vm.DisplayOrder,
                Lang = vm.Lang,
                Icon = vm.Icon,
                IconVisibility = vm.IconVisibility,
                MetaDescription = vm.MetaDescription,

            };
        }

        public static UpdateServiceDto MapFormVMToUpdateDto(this ServiceFormVM vm)
        {
            return new UpdateServiceDto
            {
                Id = vm.Id,
                Title = vm.Title,
                Slug = vm.Slug,
                Content = vm.Content,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                Section = vm.Section,
                DisplayOrder = vm.DisplayOrder,
                Lang = vm.Lang,
                Icon = vm.Icon,
                IconVisibility = vm.IconVisibility,
                MetaDescription = vm.MetaDescription,
                SEOMarkup = vm.SEOMarkup,
                PublishedDate = vm.PublishedDate,
                ModifiedDate = vm.ModifiedDate
            };
        }

    }
}


