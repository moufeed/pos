using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices.Attributes.Mapper
{
    public static class AttributesMapper
    {
        public static TamTech.ContentService.Services.Attributes.Models.CreateAttributeModel MapToBackendCreateAttribute(this TamTechSDK.Common.Services.Attributes.Models.CreateAttributeModel item)
        {
            return new ContentService.Services.Attributes.Models.CreateAttributeModel
            {
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Icon = item.Icon,
                IsOfficial = item.IsOfficial,
                Lang = item.Lang,
                Name = item.Name,
                Slug = item.Slug,
                Tags = item.Tags,
                ChoiceType = item.ChoiceType,
                InputType = item.InputType,
                IsMandatory = item.IsMandatory
            };
        }


        public static TamTech.ContentService.Services.Attributes.Models.UpdateAttributeModel MapToBackendUpdateAttribute(this TamTechSDK.Common.Services.Attributes.Models.UpdateAttributeModel item)
        {
            return new ContentService.Services.Attributes.Models.UpdateAttributeModel
            {
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Icon = item.Icon,
                Id = item.Id,
                Lang = item.Lang,
                Name = item.Name,
                Slug = item.Slug,
                Tags = item.Tags,
                ChoiceType = item.ChoiceType,
                InputType = item.InputType,
                IsMandatory = item.IsMandatory
            };
        }

        public static TamTechSDK.Common.Services.Attributes.Models.AttributeDto MapToForntAttributeDto(this TamTech.ContentService.Services.Attributes.Models.AttributeDto item)
        {
            return new TamTechSDK.Common.Services.Attributes.Models.AttributeDto
            {
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Icon = item.Icon,
                Id = item.Id,
                Lang = item.Lang,
                Name = item.Name,
                Slug = item.Slug,
                Tags = item.Tags,
                InputType = item.InputType,
                ChoiceType = item.ChoiceType,
                CreatedDate = item.CreatedDate,
                ClientId = item.ClientId,
                CreatorUserId = item.CreatorUserId,
                GroupId = item.GroupId,
                IsOfficial = item.IsOfficial,
                Locked = item.Locked,
                ModifiedDate = item.ModifiedDate,
                ModifierUserId = item.ModifierUserId,
                Published = item.Published,
                IsMandatory = item.IsMandatory,
                Values = item.Values != null ? item.Values.Select(val => val.MapToFrontValueDto()).ToList() : new List<TamTechSDK.Common.Services.Attributes.Models.ValueDto>()
            };

        }


        public static TamTechSDK.Common.Services.Attributes.Models.ValueDto MapToFrontValueDto(this TamTech.ContentService.Services.Values.Models.ValueDto item)
        {
            return new TamTechSDK.Common.Services.Attributes.Models.ValueDto
            {
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Icon = item.Icon,
                Id = item.Id,
                Lang = item.Lang,
                Name = item.Name,
                Slug = item.Slug,
                Tags = item.Tags,
                CreatedDate = item.CreatedDate,
                ClientId = item.ClientId,
                CreatorUserId = item.CreatorUserId,
                GroupId = item.GroupId,
                IsOfficial = item.IsOfficial,
                Locked = item.Locked,
                ModifiedDate = item.ModifiedDate,
                ModifierUserId = item.ModifierUserId,
                Published = item.Published,
                AttId = item.AttId,
            };
        }


    }
}
