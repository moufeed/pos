using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.ContentService.Posts.Models;
using TamTechSDK.Web.Models.Admin.Posts;


namespace TamTechSDK.Web.Extensions.AutoMapper.Posts
{
    public static class PostMapper
    {


        public static PostVM MapToPostVM(this PostDto dto)
        {
            return new PostVM
            {
                Id = dto.Id,
                Title = dto.Title,
                Slug = dto.Slug,
                Content = dto.Content,
                Summary = dto.Summary,
                MainImage = dto.MainImage,
                Section = dto.Section,
                SectionId = dto.SectionId,
                DisplayOrder = dto.DisplayOrder,
                Lang = dto.Lang,
                MetaDescription = dto.MetaDescription,
                SEOMarkup = dto.SEOMarkup,
                PublishedDate = dto.PublishedDate,
                ModifiedDate = dto.ModifiedDate,
                Locked = dto.Locked,
                Tags = dto.Tags,
                Published = dto.Published,
                SectionSlug = dto.SectionSlug,
                PostDate = dto.PostDate
            };
        }

        public static PostDto VMToDto(this PostVM vm)
        {
            return new PostDto
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
                SectionId = vm.SectionId,
                MetaDescription = vm.MetaDescription,
                SEOMarkup = vm.SEOMarkup,
                PublishedDate = vm.PublishedDate,
                ModifiedDate = vm.ModifiedDate,
                Tags = vm.Tags,
                PostDate = vm.PostDate
            };
        }

        public static CreatePostDto MapFormVMToCreateDto(this PostVM vm)
        {
            return new CreatePostDto
            {
                Title = vm.Title,
                Slug = vm.Slug,
                Content = vm.Content,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                Section = vm.Section,
                SectionId = vm.SectionId,
                DisplayOrder = vm.DisplayOrder,
                Lang = vm.Lang,
                MetaDescription = vm.MetaDescription,
                Tags = vm.Tags,
                PostDate = vm.PostDate
            };
        }

        public static UpdatePostDto MapFormVMToUpdateDto(this PostVM vm)
        {
            return new UpdatePostDto
            {
                Id = vm.Id,
                Title = vm.Title,
                Slug = vm.Slug,
                Content = vm.Content,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                Section = vm.Section,
                SectionId = vm.SectionId,
                DisplayOrder = vm.DisplayOrder,
                Lang = vm.Lang,
                MetaDescription = vm.MetaDescription,
                SEOMarkup = vm.SEOMarkup,
                PublishedDate = vm.PublishedDate,
                ModifiedDate = vm.ModifiedDate,
                Tags = vm.Tags,
                PostDate = vm.PostDate
            };
        }

    }
}


