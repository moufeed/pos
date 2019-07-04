using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Slugs;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices
{
    public static class BaseDirectMapper
    {
        public static TamTech.ContentService.Core.Domain.Models.DTFilterModel MapToBackDTFilter(this TamTech.Monshaat.POS.Web.Models.Dtos.Filter.DTFilter item)
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

        public static TamTech.ContentService.Services.POSs.Models.POSFilterModel MapToBackPosFilter(this TamTech.Monshaat.POS.Web.Services.PosService.Directory.Models.PosFilters item)
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


        public static TamTech.Monshaat.POS.Web.Models.Dtos.Pagination.PaginationMetadataModel MapToFrontPagination(this TamTech.ContentService.Core.Domain.Models.PaginationMetadataModel item)
        {
            return new TamTech.Monshaat.POS.Web.Models.Dtos.Pagination.PaginationMetadataModel
            {
                TotalCount = item.TotalCount,
                PageSize = item.PageSize,
                PageNumber = item.PageNumber.ToString(),
                TotalPages = item.TotalPages,
                PreviousPage = item.PreviousPage,
                NextPage = item.NextPage
            };
        }


        public static TamTech.Monshaat.POS.Web.Models.Dtos.Slugs.SlugModel MapToFrontSlug(this TamTech.ContentService.Services.Shared.Dtos.SlugModel item)
        {
            return new TamTech.Monshaat.POS.Web.Models.Dtos.Slugs.SlugModel
            {
                Lang = item.Lang,
                Slug = item.Slug
            };
        }


        public static TamTech.ContentService.Services.Shared.Dtos.PublishLookupModel MapToBackendPuplishModel(this  PublishDTO frontend)
        {
            return new TamTech.ContentService.Services.Shared.Dtos.PublishLookupModel
            {
                Id = frontend.IntId,
                Lang = frontend.Lang,

            };
        }

        public static TamTech.ContentService.Services.Shared.Dtos.PublishModel MapToBackendPuplish(this  PublishDTO frontend)
        {
            return new TamTech.ContentService.Services.Shared.Dtos.PublishModel
            {
                Id = frontend.Id,
                Lang = frontend.Lang,

            };
        }

        public static TamTech.Monshaat.POS.Web.Models.Dtos.SelectList.SelectListItemModel MapToForntSelectListItemModel(this TamTech.ContentService.Core.Domain.Models.SelectListItemModel item)
        {
            return new TamTech.Monshaat.POS.Web.Models.Dtos.SelectList.SelectListItemModel
            {
                Text = item.Text,
                Value = item.Value
            };
        }

        public static  GeneratedSlugModel MapToFrontGeneratedSlugModel(this TamTech.ContentService.Services.Shared.Models.GeneratedSlugModel item)
        {
            return new  GeneratedSlugModel
            {
                Slug = item.Slug,
                Unique = item.Unique
            };
        }

        public static TamTech.ContentService.Services.Shared.Dtos.ActiveModel MaptoBackActiveModel(this  ActiveModel item)
        {
            return new ContentService.Services.Shared.Dtos.ActiveModel
            {
                Id = item.Id,
                Lang = item.Lang,

            };
        }
        public static TamTech.ContentService.Services.Shared.Models.SetActionModel MapToBackSetAction(this  SetActionModel item)
        {
            return new TamTech.ContentService.Services.Shared.Models.SetActionModel
            {
                Id = item.Id,
                Lang = item.Lang,
                ActionId = item.ActionId,
                Notes = item.Notes
            };
        }

        public static  ProcessActionModel MapToFrontProcessActionModel(this TamTech.ContentService.Services.Shared.Models.ProcessActionModel item)
        {
            return new  ProcessActionModel
            {
                ActionId = item.ActionId,
                Name = item.Name,
                NoteMandatory = item.NoteMandatory
            };
        }
    }
}
