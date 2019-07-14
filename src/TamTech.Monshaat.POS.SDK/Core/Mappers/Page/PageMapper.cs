using System;
using TamTech.Monshaat.POS.Web.Services.ContentService.Pages.Models;
using TamTech.Monshaat.POS.Web.Models.VMs.Admin.Page;

namespace TamTech.Monshaat.POS.Web.Core.Mappers
{
    public static class PageMapper
    {
        public static CreateHtmlPageDto MapToDto(this HtmlPageCreationVM vm)
        {
            return new CreateHtmlPageDto
            {
                Title = vm.Title,
                Slug = vm.Slug,
                Content = vm.Content,
                Keywords = vm.KeywordsList,
                Section = vm.Section,
                MainImage = vm.MainImage,
                Summary = vm.Summary,
                Lang = vm.Lang,
                MetaDescription = vm.MetaDescription,
                DisplayOrder = vm.DisplayOrder,
                AuthorName = vm.AuthorName,
                Key = vm.Key,
            };
        }

        public static HtmlPageCreationVM MapToViewModel(this CreateHtmlPageDto dto)
        {
            return new HtmlPageCreationVM
            {
                Title = dto.Title,
                Slug = dto.Slug,
                Content = dto.Content,
                KeywordsList = dto.Keywords,
                Summary = dto.Summary,
                MainImage = dto.MainImage,
                Section = dto.Section,
                Lang = dto.Lang,
                MetaDescription = dto.MetaDescription,
                DisplayOrder = dto.DisplayOrder,
                AuthorName = dto.AuthorName,
                Key = dto.Key,
            };
        }



        /////////////////////
        public static EditHtmlPageDto MapEditToEditDto(this HtmlPageEditingVM vm)
        {
            return new EditHtmlPageDto
            {
                Id = vm.Id,
                Title = vm.Title,
                Slug = vm.Slug,
                Content = vm.Content,
                Keywords = vm.KeywordsList,
                Section = vm.Section,
                MainImage = vm.MainImage,
                Summary = vm.Summary,
                Lang = vm.Lang,
                DisplayOrder = vm.DisplayOrder,
                MetaDescription = vm.MetaDescription,
                SEOMarkup = vm.SEOMarkup,
                ModifiedDate = vm.ModifiedDate,
                PublishedDate = vm.PublishedDate,
                AuthorName = vm.AuthorName,
                Key = vm.Key,
            };
        }

        public static HtmlPageEditingVM MapEditToEditVM(this EditHtmlPageDto dto)
        {
            return new HtmlPageEditingVM
            {
                Id = dto.Id,
                Title = dto.Title,
                Slug = dto.Slug,
                Content = dto.Content,
                KeywordsList = dto.Keywords,
                Summary = dto.Summary,
                MainImage = dto.MainImage,
                Section = dto.Section,
                Lang = dto.Lang,
                MetaDescription = dto.MetaDescription,
                DisplayOrder = dto.DisplayOrder,
                SEOMarkup = dto.SEOMarkup,
                ModifiedDate = dto.ModifiedDate,
                PublishedDate = dto.PublishedDate,
                AuthorName = dto.AuthorName,
                Locked = dto.Locked,
                Key = dto.Key,
            };
        }


        public static HtmlPageEditingVM MapToEditingVM(this HtmlPage Dto)
        {
            return new HtmlPageEditingVM
            {
                Id = Dto.Id,
                Title = Dto.Title,
                Slug = Dto.Slug,
                Content = Dto.Content,
                KeywordsList = Dto.Keywords,
                Summary = Dto.Summary,
                MainImage = Dto.MainImage,
                Section = Dto.Section,
                Lang = Dto.Lang,
                MetaDescription = Dto.MetaDescription,
                DisplayOrder = Dto.DisplayOrder,
                ModifiedDate = Dto.ModifiedDate,
                PublishedDate = Dto.PublishedDate,
                SEOMarkup = Dto.SEOMarkup,
                AuthorName = Dto.AuthorName,
                Locked = Dto.Locked,
                Published = Dto.Published,
                Key = Dto.Key,
            };
        }
        ///////////////
        public static HtmlPage MapToDto(this HtmlPageVM vm)
        {
            return new HtmlPage
            {
                Id = vm.Id,
                Title = vm.Title,
                Slug = vm.Slug,
                CreatedDate = vm.CreatedDate,
                ModifiedDate = vm.ModifiedDate,
                ModifierUserId = vm.ModifierUserId,
                CreatorUserId = vm.CreatorUserId,
                ClientId = vm.ClientId,
                Published = vm.Published,
                Type = vm.Type,
                Keywords = vm.Keywords,
                DisplayOrder = vm.DisplayOrder,
                TypeEnum = vm.TypeEnum,
                Content = vm.Content,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                Section = vm.Section,
                Lang = vm.Lang,
                MetaDescription = vm.MetaDescription,
                SEOMarkup = vm.SEOMarkup,
                PublishedDate = vm.PublishedDate,
                AuthorName = vm.AuthorName,
                Key = vm.Key,

            };
        }

        public static HtmlPageVM MapToViewModel(this HtmlPage dto)
        {
            return new HtmlPageVM
            {
                Id = dto.Id,
                Title = dto.Title,
                Slug = dto.Slug,
                CreatedDate = dto.CreatedDate,
                ModifiedDate = dto.ModifiedDate,
                ModifierUserId = dto.ModifierUserId,
                CreatorUserId = dto.CreatorUserId,
                ClientId = dto.ClientId,
                Published = dto.Published,
                Type = dto.Type,
                Keywords = dto.Keywords,
                DisplayOrder = dto.DisplayOrder,
                TypeEnum = dto.TypeEnum,
                Content = dto.Content,
                Summary = dto.Summary,
                MainImage = dto.MainImage,
                Section = dto.Section,
                Lang = dto.Lang,
                MetaDescription = dto.MetaDescription,
                SEOMarkup = dto.SEOMarkup,
                PublishedDate = dto.PublishedDate,
                AuthorName = dto.AuthorName,
                Locked = dto.Locked,
                Key = dto.Key,
            };
        }
        ///////////////
        public static CreateSectionsPageDto MapToDto(this SectionsPageCreationVM vm)
        {
            return new CreateSectionsPageDto
            {
                Title = vm.Title,
                Slug = vm.Slug,
                Content = vm.Content,
                Keywords = vm.KeywordsList,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                Section = vm.Section,
                Lang = vm.Lang,
                MetaDescription = vm.MetaDescription,
                DisplayOrder = vm.DisplayOrder,
                AuthorName = vm.AuthorName,
                Key = vm.Key,

            };
        }

        public static SectionsPageCreationVM MapToViewModel(this CreateSectionsPageDto dto)
        {
            return new SectionsPageCreationVM
            {
                Title = dto.Title,
                Slug = dto.Slug,
                Content = dto.Content,
                KeywordsList = dto.Keywords,
                Summary = dto.Summary,
                MainImage = dto.MainImage,
                Section = dto.Section,
                Lang = dto.Lang,
                MetaDescription = dto.MetaDescription,
                DisplayOrder = dto.DisplayOrder,
                AuthorName = dto.AuthorName,
                Key = dto.Key,
            };
        }
        ///////////////////

        public static EditSectionsPageDto MapEditToEditDto(this SectionsPageEditingVM vm)
        {
            return new EditSectionsPageDto
            {
                Id = vm.Id,
                Title = vm.Title,
                Slug = vm.Slug,
                Content = vm.Content,
                Keywords = vm.KeywordsList,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                Section = vm.Section,
                Lang = vm.Lang,
                DisplayOrder = vm.DisplayOrder,
                MetaDescription = vm.MetaDescription,
                SEOMarkup = vm.SEOMarkup,
                PublishedDate = vm.PublishedDate,
                ModifiedDate = vm.ModifiedDate,
                AuthorName = vm.AuthorName,
                Key = vm.Key,
            };
        }

        public static SectionsPageEditingVM MapEditToEditVM(this EditSectionsPageDto dto)
        {
            return new SectionsPageEditingVM
            {
                Id = dto.Id,
                Title = dto.Title,
                Slug = dto.Slug,
                Content = dto.Content,
                KeywordsList = dto.Keywords,
                Summary = dto.Summary,
                MainImage = dto.MainImage,
                Section = dto.Section,
                Lang = dto.Lang,
                DisplayOrder = dto.DisplayOrder,
                MetaDescription = dto.MetaDescription,
                SEOMarkup = dto.SEOMarkup,
                ModifiedDate = dto.ModifiedDate,
                PublishedDate = dto.PublishedDate,
                AuthorName = dto.AuthorName,
                Locked = dto.Locked,
                Key = dto.Key,
            };
        }

        public static SectionsPageEditingVM MapToEditingVM(this SectionsPage Dto)
        {
            return new SectionsPageEditingVM
            {
                Id = Dto.Id,
                Title = Dto.Title,
                Slug = Dto.Slug,
                Content = Dto.Content,
                KeywordsList = Dto.Keywords,
                Summary = Dto.Summary,
                MainImage = Dto.MainImage,
                Section = Dto.Section,
                Lang = Dto.Lang,
                DisplayOrder = Dto.DisplayOrder,
                MetaDescription = Dto.MetaDescription,
                SEOMarkup = Dto.SEOMarkup,
                ModifiedDate = Dto.ModifiedDate,
                PublishedDate = Dto.PublishedDate,
                AuthorName = Dto.AuthorName,
                Locked = Dto.Locked,
                Published = Dto.Published,
                Key = Dto.Key,
            };
        }

    }
}
