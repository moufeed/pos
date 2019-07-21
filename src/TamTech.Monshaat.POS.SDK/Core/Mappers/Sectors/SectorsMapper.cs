using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Sectors;

namespace TamTech.Monshaat.POS.Web.SDK.Core.Mappers.Sectors
{
    public static class SectorsMapper
    {

        public static SectorVM MapToSectorVM(this TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sectors.Models.SectorDto item)
        {
            return new SectorVM
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

        public static TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sectors.Models.UpdateSectorModel MapToUpdateSectorModel(this SectorVM item)
        {
            return new TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sectors.Models.UpdateSectorModel
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
        public static TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sectors.Models.CreateSectorModel MapToCreateSectorModel(this SectorVM item)
        {
            return new TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sectors.Models.CreateSectorModel
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
