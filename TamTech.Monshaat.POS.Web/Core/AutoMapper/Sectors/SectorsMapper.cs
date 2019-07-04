using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Extensions.AutoMapper.Sectors
{
    public static class SectorsMapper
    {

        public static Models.Admin.Sectors.SectorVM MapToSectorVM(this TamTechSDK.Common.Services.PosService.Sectors.Models.SectorDto item)
        {
            return new Models.Admin.Sectors.SectorVM
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Published = item.Published,
                IsOfficial = item.IsOfficial,
                GroupId = item.GroupId,
                Id = item.Id,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate,
                ModifierUserId = item.ModifierUserId,
                CreatorUserId = item.CreatorUserId,
                ClientId = item.ClientId,
                Locked = item.Locked,
                ParentId = item.ParentId,
                Image = item.Image
            };
        }

        public static TamTechSDK.Common.Services.PosService.Sectors.Models.UpdateSectorModel MapToUpdateSectorModel(this Models.Admin.Sectors.SectorVM item)
        {
            return new TamTechSDK.Common.Services.PosService.Sectors.Models.UpdateSectorModel
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Lang = item.Lang,
                IsOfficial = item.IsOfficial,
                ParentId = item.ParentId,
                Image = item.Image
            };
        }
        public static TamTechSDK.Common.Services.PosService.Sectors.Models.CreateSectorModel MapToCreateSectorModel(this Models.Admin.Sectors.SectorVM item)
        {
            return new TamTechSDK.Common.Services.PosService.Sectors.Models.CreateSectorModel
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Lang = item.Lang,
                IsOfficial = item.IsOfficial,
                ParentId = item.ParentId,
                Image = item.Image
            };
        }

    }
}
