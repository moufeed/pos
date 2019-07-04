using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TamTechSDK.Common.Services.ContentService.Galleries.Models;
using TamTechSDK.Web.Models.Admin.Galleries;

namespace TamTechSDK.Web.Extensions.AutoMapper.Galleries
{
    public static class GalleriesMapper
    {
        #region Gallery  // G
        public static CreateGalleryDto MapVmToCreateDto(this GalleryFormVM vm)
        {
            return new CreateGalleryDto
            {

                Title = vm.Title,
                Slug = vm.Slug,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                Section = vm.Section,
                DisplayOrder = vm.DisplayOrder,
                Lang = vm.Lang,
                MetaDescription = vm.MetaDescription,
                AuthorName = vm.AuthorName,
                CustomDate = vm.CustomDate
            };
        }

        public static UpdateGalleryDto MapVmToUpdateDto(this GalleryFormVM vm)
        {
            return new UpdateGalleryDto
            {
                Id = vm.Id,
                Title = vm.Title,
                Slug = vm.Slug,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                Section = vm.Section,
                DisplayOrder = vm.DisplayOrder,
                Lang = vm.Lang,
                MetaDescription = vm.MetaDescription,
                SEOMarkup = vm.SEOMarkup,
                ModifiedDate = vm.ModifiedDate,
                PublishedDate = (vm.PublishedDate != null) ? (DateTime)vm.PublishedDate : vm.CreatedDate,
                AuthorName = vm.AuthorName,
                CustomDate = vm.CustomDate
            };
        }

        public static GalleryFormVM MapGDtoToGVm(this GalleryDto Dto)
        {
            return new GalleryFormVM
            {
                Id = Dto.Id,
                Title = Dto.Title,
                Slug = Dto.Slug,
                Summary = Dto.Summary,
                MainImage = Dto.MainImage,
                Section = Dto.Section,
                DisplayOrder = Dto.DisplayOrder,
                Lang = Dto.Lang,
                Items = Dto.Items != null ? Dto.Items.Select(p => p.MapGiDtoToGiVm()).ToList() : new List<GalleryItemFormVM>(),
                Published = Dto.Published,
                MetaDescription = Dto.MetaDescription,
                SEOMarkup = Dto.SEOMarkup,
                ModifiedDate = Dto.ModifiedDate,
                PublishedDate = Dto.PublishedDate,
                CreatedDate = Dto.CreatedDate,
                AuthorName = Dto.AuthorName,
                Locked = Dto.Locked,
                CustomDate = Dto.CustomDate
            };
        }

        #endregion


        #region Gallery item  //  Gi


        public static GalleryItemFormVM MapGiDtoToGiVm(this GalleryItemDto dto)
        {
            return new GalleryItemFormVM
            {

                Lang = dto.Lang,
                Title = dto.Title,
                Id = dto.Id,
                Slug = dto.Slug,
                Summary = dto.Summary,
                MainImage = dto.MainImage,
                DisplayOrder = dto.DisplayOrder,
                Published = dto.Published,
                CreatedDate = dto.CreatedDate,
                MetaDescription = dto.MetaDescription,
                GalleryItemType = dto.GalleryItemType,
                VideoUrl = dto.VideoUrl
            };
        }


        public static GalleryItemFormVM MapCreateDtoToVm(this CreateGalleryItemDto vm)
        {
            return new GalleryItemFormVM
            {
                Lang = vm.Lang,
                Title = vm.Title,
                GalleryId = vm.GalleryId,
                Slug = vm.Slug,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                DisplayOrder = vm.DisplayOrder,
                MetaDescription = vm.MetaDescription,
                GalleryItemType = vm.GalleryItemType,
                VideoUrl = vm.VideoUrl
            };
        }
        public static CreateGalleryItemDto MapGiVmToCreateGiDto(this GalleryItemFormVM vm)
        {
            return new CreateGalleryItemDto
            {
                Lang = vm.Lang,
                Title = vm.Title,
                GalleryId = vm.GalleryId,
                Slug = vm.Slug,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                DisplayOrder = vm.DisplayOrder,
                MetaDescription = vm.MetaDescription,
                GalleryItemType = vm.GalleryItemType,
                VideoUrl = vm.VideoUrl
            };
        }

        public static UpdateGalleryItemDto MapGiVmToUpdateGiDto(this GalleryItemFormVM vm)
        {
            return new UpdateGalleryItemDto
            {
                Lang = vm.Lang,
                Title = vm.Title,
                Id = vm.Id,
                GalleryId = vm.GalleryId,
                Slug = vm.Slug,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                DisplayOrder = vm.DisplayOrder,
                MetaDescription = vm.MetaDescription,
                GalleryItemType = vm.GalleryItemType,
                VideoUrl = vm.VideoUrl
            };
        }

        #endregion
    }
}




