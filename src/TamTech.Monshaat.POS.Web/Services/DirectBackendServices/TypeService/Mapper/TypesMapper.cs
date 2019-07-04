using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.TypeService.Mapper
{
    public static class TypesMapper
    {



        public static TamTech.ContentService.Services.Types.Models.CreateTypeModel MapToBackCreateType(this TamTech.Monshaat.POS.Web.Services.TypesService.Models.CreateTypeModel item)
        {
            return new ContentService.Services.Types.Models.CreateTypeModel
            {
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                //GroupId = item.GroupId,
                Icon = item.Icon,
                IsOfficial = item.IsOfficial,
                Lang = item.Lang,
                Name = item.Name,
                Options = item.Options,
                ParentId = item.ParentId,
                Slug = item.Slug,
                Tags = item.Tags
            };


        }


        public static TamTech.ContentService.Services.Types.Models.UpdateTypeModel MapToBackUpdateModele(this TamTech.Monshaat.POS.Web.Services.TypesService.Models.UpdateTypeModel item)
        {
            return new ContentService.Services.Types.Models.UpdateTypeModel
            {
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Icon = item.Icon,
                Lang = item.Lang,
                Name = item.Name,
                Options = item.Options,
                ParentId = item.ParentId,
                Slug = item.Slug,
                Tags = item.Tags,
                Id = item.Id
            };
        }



        public static TamTech.Monshaat.POS.Web.Services.TypesService.Models.TypeDto MapToForntTypeDto(this ContentService.Services.Types.Models.TypeDto item)
        {
            return new TamTech.Monshaat.POS.Web.Services.TypesService.Models.TypeDto
            {
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Icon = item.Icon,
                Lang = item.Lang,
                Name = item.Name,
                Options = item.Options,
                Slug = item.Slug,
                Tags = item.Tags,
                Id = item.Id,
                ClientId = item.ClientId,
                CreatedDate = item.CreatedDate,
                CreatorUserId = item.CreatorUserId,
                GroupId = item.GroupId,
                IsOfficial = item.IsOfficial,
                Locked = item.Locked,
                ModifiedDate = item.ModifiedDate,
                ModifierUserId = item.ModifierUserId,
                Published = item.Published
            };
        }
    }
}
