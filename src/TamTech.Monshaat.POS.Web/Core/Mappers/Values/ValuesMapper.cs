using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.ValuesServices.Models;
using TamTechSDK.Web.Models.Admin.Values;

namespace TamTechSDK.Web.Extensions.AutoMapper.Values
{
    public static class ValuesMapper
    {

        public static Common.Services.ValuesServices.Models.CreateValueModel MapToCreateValueModel(this ValueVM item)
        {
            return new Common.Services.ValuesServices.Models.CreateValueModel
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Lang = item.Lang,
                AttId = item.AttId,
                Image = item.Icon,
                GroupId = item.GroupId,
                IsOfficial = item.IsOfficial
            };
        }

        public static ValueVM MapToValueVM(this ValueDto item)
        {
            return new ValueVM
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                AttId = item.AttId,
                Published = item.Published,
                GroupId = item.GroupId,
                CreatedDate = item.CreatedDate,
                Locked = item.Locked,
                ModifiedDate = item.ModifiedDate,
                Lang = item.Lang,
                IsOfficial = item.IsOfficial,
                Id = item.Id
            };
        }


        public static UpdateValueModel MapToUpdateAttributeModel(this ValueVM item)
        {
            return new UpdateValueModel
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Lang = item.Lang,
                Id = item.Id,
                AttId = item.AttId,
                Image = item.Icon,
                GroupId = item.GroupId,
                IsOfficial = item.IsOfficial
            };
        }
    }
}
