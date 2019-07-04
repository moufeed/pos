using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TamTechSDK.Common.Services.Attributes.Models;
using TamTechSDK.Web.Models.Admin.Attributes;
using TamTechSDK.Web.Models.Admin.Values;

namespace TamTechSDK.Web.Extensions.AutoMapper.Attributes
{
    public static class AttributesMapper
    {

        public static CreateAttributeModel MapToCreateAttributeModel(this AttributeVM item)
        {
            return new CreateAttributeModel
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Lang = item.Lang,
                ChoiceType = item.ChoiceType,
                IsOfficial = item.IsOfficial,
                IsMandatory = item.IsMandatory,
                InputType = item.InputType

            };
        }

        public static AttributeVM MapToAttributeVM(this AttributeDto item)
        {
            return new AttributeVM
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Published = item.Published,
                GroupId = item.GroupId,
                CreatedDate = item.CreatedDate,
                Locked = item.Locked,
                ModifiedDate = item.ModifiedDate,
                Lang = item.Lang,
                IsOfficial = item.IsOfficial,
                Id = item.Id,
                IsMandatory = item.IsMandatory,
                InputType = item.InputType,
                ChoiceType = item.ChoiceType,
                Values = item.Values?.Select(m => m.MapToValueVM()).ToList()
            };
        }



        public static UpdateAttributeModel MapToUpdateAttributeModel(this AttributeVM item)
        {
            return new UpdateAttributeModel
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
                InputType = item.InputType,
                IsMandatory = item.IsMandatory,
                ChoiceType = item.ChoiceType,
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
                Lang = item.Lang,
                Id = item.Id,
                AttId = item.AttId,
                Locked = item.Locked,
                Published = item.Published,
                CreatedDate = item.CreatedDate,
                IsOfficial = item.IsOfficial,
            };
        }
    }
}
