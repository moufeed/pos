using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Services.ValuesServices.Models;
using TamTech.Monshaat.POS.Web.Models.VMs.Admin.Values;

namespace TamTech.Monshaat.POS.Web.Core.Mappers.Values
{
    public static class ValuesMapper
    {

        public static CreateValueModel MapToCreateValueModel(this ValueVM item)
        {
            return new CreateValueModel
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
