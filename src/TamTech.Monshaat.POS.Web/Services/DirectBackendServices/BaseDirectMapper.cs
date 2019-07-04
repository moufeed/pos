using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices
{
    public static class BaseDirectMapper
    {
        public static TamTech.ContentService.Core.Domain.Models.DTFilterModel MapToBackDTFilter(this TamTechSDK.Common.Models.Filter.DTFilter item)
        {
            return new TamTech.ContentService.Core.Domain.Models.DTFilterModel
            {
                Descending = item.Descending,
                Lang = item.Lang,
                PageNumber = item.PageNumber,
                PageSize = item.PageSize,
                SortBy = item.SortBy,
                Search = item.Search
            };
        }

        public static TamTech.ContentService.Services.POSs.Models.POSFilterModel MapToBackPosFilter(this TamTechSDK.Common.Services.PosService.Directory.Models.PosFilters item)
        {
            return new TamTech.ContentService.Services.POSs.Models.POSFilterModel
            {
                Descending = item.Descending,
                Lang = item.Lang,
                PageNumber = item.PageNumber,
                PageSize = item.PageSize,
                SortBy = item.SortBy,
                Search = item.Search
            };
        }


        public static TamTechSDK.Common.Models.Pagination.PaginationMetadataModel MapToFrontPagination(this TamTech.ContentService.Core.Domain.Models.PaginationMetadataModel item)
        {
            return new TamTechSDK.Common.Models.Pagination.PaginationMetadataModel
            {
                TotalCount = item.TotalCount,
                PageSize = item.PageSize,
                PageNumber = item.PageNumber.ToString(),
                TotalPages = item.TotalPages,
                PreviousPage = item.PreviousPage,
                NextPage = item.NextPage
            };
        }


        public static TamTechSDK.Common.Models.Languages.SlugModel MapToFrontSlug(this TamTech.ContentService.Services.Shared.Dtos.SlugModel item)
        {
            return new TamTechSDK.Common.Models.Languages.SlugModel
            {
                Lang = item.Lang,
                Slug = item.Slug
            };
        }


        public static TamTech.ContentService.Services.Shared.Dtos.PublishLookupModel MapToBackendPuplishModel(this TamTechSDK.Common.Models.ContentItem.PublishDTO frontend)
        {
            return new TamTech.ContentService.Services.Shared.Dtos.PublishLookupModel
            {
                Id = frontend.IntId,
                Lang = frontend.Lang,

            };
        }

        public static TamTech.ContentService.Services.Shared.Dtos.PublishModel MapToBackendPuplish(this TamTechSDK.Common.Models.ContentItem.PublishDTO frontend)
        {
            return new TamTech.ContentService.Services.Shared.Dtos.PublishModel
            {
                Id = frontend.Id,
                Lang = frontend.Lang,

            };
        }

        public static TamTechSDK.Common.Models.SelectList.SelectListItemModel MapToForntSelectListItemModel(this TamTech.ContentService.Core.Domain.Models.SelectListItemModel item)
        {
            return new TamTechSDK.Common.Models.SelectList.SelectListItemModel
            {
                Text = item.Text,
                Value = item.Value
            };
        }

        public static TamTechSDK.Common.Services.Shared.Models.GeneratedSlugModel MapToFrontGeneratedSlugModel(this TamTech.ContentService.Services.Shared.Models.GeneratedSlugModel item)
        {
            return new TamTechSDK.Common.Services.Shared.Models.GeneratedSlugModel
            {
                Slug = item.Slug,
                Unique = item.Unique
            };
        }

        public static TamTech.ContentService.Services.Shared.Dtos.ActiveModel MaptoBackActiveModel(this TamTechSDK.Common.Models.ContentItem.ActiveModel item)
        {
            return new ContentService.Services.Shared.Dtos.ActiveModel
            {
                Id = item.Id,
                Lang = item.Lang,

            };
        }
        public static TamTech.ContentService.Services.Shared.Models.SetActionModel MapToBackSetAction(this TamTechSDK.Common.Services.Shared.Models.SetAction item)
        {
            return new TamTech.ContentService.Services.Shared.Models.SetActionModel
            {
                Id = item.Id,
                Lang = item.Lang,
                ActionId = item.ActionId,
                Notes = item.Notes
            };
        }

        public static TamTechSDK.Common.Services.Shared.Models.ProcessActionModel MapToFrontProcessActionModel(this TamTech.ContentService.Services.Shared.Models.ProcessActionModel item)
        {
            return new TamTechSDK.Common.Services.Shared.Models.ProcessActionModel
            {
                ActionId = item.ActionId,
                Name = item.Name,
                NoteMandatory = item.NoteMandatory
            };
        }
    }
}
