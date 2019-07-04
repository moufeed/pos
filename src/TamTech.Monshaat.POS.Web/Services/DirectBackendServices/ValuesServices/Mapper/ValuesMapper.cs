using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ValuesServices.Mapper
{
    public static class ValuesMapper
    {

        public static TamTech.ContentService.Services.Values.Models.CreateValueModel MapToBackendCreateValueModel(this TamTech.Monshaat.POS.Web.Services.ValuesServices.Models.CreateValueModel item)
        {
            return new ContentService.Services.Values.Models.CreateValueModel
            {
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Icon = item.Icon,
                AttId = item.AttId,
                Lang = item.Lang,
                Name = item.Name,
                Slug = item.Slug,
                Tags = item.Tags,
                GroupId = item.GroupId,
                IsOfficial = item.IsOfficial
            };
        }

        public static TamTech.ContentService.Services.Values.Models.UpdateValueModel MapToBackendUpdateValueModel(this TamTech.Monshaat.POS.Web.Services.ValuesServices.Models.UpdateValueModel item)
        {
            return new ContentService.Services.Values.Models.UpdateValueModel
            {
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Icon = item.Icon,
                AttId = item.AttId,
                Lang = item.Lang,
                Name = item.Name,
                Slug = item.Slug,
                Tags = item.Tags,
                //GroupId = item.GroupId,
                //IsOfficial = item.IsOfficial,
                Id = item.Id
            };
        }

        public static TamTech.Monshaat.POS.Web.Services.ValuesServices.Models.ValueDto MapToForntValueDto(this ContentService.Services.Values.Models.ValueDto item)
        {
            return new TamTech.Monshaat.POS.Web.Services.ValuesServices.Models.ValueDto
            {
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Icon = item.Icon,
                AttId = item.AttId,
                Lang = item.Lang,
                Name = item.Name,
                Slug = item.Slug,
                Tags = item.Tags,
                GroupId = item.GroupId,
                IsOfficial = item.IsOfficial,
                Id = item.Id,
                CreatedDate = item.CreatedDate,
                ClientId = item.ClientId,
                CreatorUserId = item.CreatorUserId,
                Locked = item.Locked,
                ModifiedDate = item.ModifiedDate,
                ModifierUserId = item.ModifierUserId,
                Published = item.Published,
                AttributeName = item.AttributeName
            };
        }
    }
}
