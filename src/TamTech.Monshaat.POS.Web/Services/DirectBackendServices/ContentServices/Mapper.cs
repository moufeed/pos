using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices
{
    public static class Mapper
    {

        public static TamTech.ContentService.Services.Shared.Dtos.PublishModel MapToBackend(this TamTech.Monshaat.POS.Web.Models.Dtos.Common.PublishDTO frontend)
        {
            return new TamTech.ContentService.Services.Shared.Dtos.PublishModel
            {
                Id = frontend.Id,
                Lang = frontend.Lang,

            };
        }


        public static TamTech.Monshaat.POS.Web.Models.Dtos.SelectList.SelectListItemModel MapToFrontEndSelectListItemModel(this TamTech.ContentService.Core.Domain.Models.SelectListItemModel item)
        {
            return new TamTech.Monshaat.POS.Web.Models.Dtos.SelectList.SelectListItemModel
            {
                Text = item.Text,
                Value = item.Value
            };
        }




        public static TamTech.ContentService.Core.Domain.Models.PaginationParamsModel toBackendPaginationModel(this TamTech.Monshaat.POS.Web.Models.Dtos.Pagination.PaginationModel item)
        {
            return new TamTech.ContentService.Core.Domain.Models.PaginationParamsModel
            {
                PageNumber = item.PageNumber,
                PageSize = item.PageSize
            };
        }





        public static TamTech.Monshaat.POS.Web.Models.Dtos.Pagination.PaginationMetadataModel MapToForntEndPagination(this TamTech.ContentService.Core.Domain.Models.PaginationMetadataModel item)
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



        public static TamTech.ContentService.Core.Domain.Models.PaginationParamsModel MapToBackendPaginationModel(this TamTech.Monshaat.POS.Web.Models.Dtos.Pagination.PaginationModel item)
        {
            return new TamTech.ContentService.Core.Domain.Models.PaginationParamsModel
            {
                PageNumber = item.PageNumber,
                PageSize = item.PageSize
            };
        }

        public static TamTech.ContentService.Core.Domain.Models.SortingModel MapToBackendSortingModel(this TamTech.Monshaat.POS.Web.Models.Dtos.Sort.SortingModel item)
        {
            return new TamTech.ContentService.Core.Domain.Models.SortingModel
            {
                SortBy = item.SortBy,
                Descending = item.Descending
            };
        }



        public static TamTech.Monshaat.POS.Web.Models.Dtos.Slugs.SlugModel MapSlugsToFrontend(this TamTech.ContentService.Services.Shared.Dtos.SlugModel item)
        {
            return new TamTech.Monshaat.POS.Web.Models.Dtos.Slugs.SlugModel
            {
                Lang = item.Lang,
                Slug = item.Slug
            };
        }

        public static TamTech.ContentService.Services.Shared.Models.AttachmentModel MapToBackAttachments(this TamTech.Monshaat.POS.Web.Models.Dtos.Attachments.AttachmentModel item)
        {
            return new ContentService.Services.Shared.Models.AttachmentModel
            {
                FullUrl = item.FullUrl,
                Name = item.Name,
                Extension = item.Extension,
                Path = item.Path,
                Thumbnail = item.Thumbnail,
                GenericField = item.GenericField
            };
        }


        public static TamTech.Monshaat.POS.Web.Services.ContentService.Status.Models.StatusDto MapToFrontStatusDto(this TamTech.ContentService.Services.Statuses.Models.StatusDto item)
        {
            return new TamTech.Monshaat.POS.Web.Services.ContentService.Status.Models.StatusDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Options = item.Options,
                GenericField = item.GenericField,
                DisplayOrder = item.DisplayOrder,
                Lang = item.Lang
            };
        }
    }
}
