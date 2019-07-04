using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TamTech.Monshaat.POS.Web.DirectBackendServices.RegionsServices.Mapper
{
    public static class RegionsMapper
    {

        public static TamTech.ContentService.Services.Regions.Models.CreateRegionModel MapToBackCreateRegionModel(this TamTech.Monshaat.POS.Web.Services.Regions.Models.CreateRegionModel item)
        {
            return new ContentService.Services.Regions.Models.CreateRegionModel
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Lang = item.Lang,
                ParentId = item.ParentId,
                IsOfficial = item.IsOfficial
            };
        }

        public static TamTech.ContentService.Services.Regions.Models.UpdateRegionModel MapToBackUpdateRegionModel(this TamTech.Monshaat.POS.Web.Services.Regions.Models.UpdateRegionModel item)
        {
            return new ContentService.Services.Regions.Models.UpdateRegionModel
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Lang = item.Lang,
                ParentId = item.ParentId,
                Id = item.Id

            };
        }

        public static TamTech.Monshaat.POS.Web.Services.Regions.Models.RegionDto MapToFrontRegionDto(this TamTech.ContentService.Services.Regions.Models.RegionDto item)
        {
            return new TamTech.Monshaat.POS.Web.Services.Regions.Models.RegionDto
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Lang = item.Lang,
                //Image = item.Image,
                Published = item.Published,
                IsOfficial = item.IsOfficial,
                GroupId = item.GroupId,
                Id = item.Id,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate,
                ModifierUserId = item.ModifierUserId,
                CreatorUserId = item.CreatorUserId,
                ClientId = item.ClientId,
                Locked = item.Locked
            };
        }


    }
}
