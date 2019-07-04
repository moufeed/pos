using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices.Sectors.Mapper
{
    public static class SectorsMapper
    {
        public static TamTech.Monshaat.POS.Web.Services.PosService.Sectors.Models.SectorDto MapToForntSectorDto(this TamTech.ContentService.Services.Sectors.Dtos.SectorDto item)
        {
            return new TamTech.Monshaat.POS.Web.Services.PosService.Sectors.Models.SectorDto
            {
                Id = item.Id,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate,
                ModifierUserId = item.ModifierUserId,
                CreatorUserId = item.CreatorUserId,
                ClientId = item.ClientId,
                Locked = item.Locked,
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
                Image = item.Image
            };
        }

        public static TamTech.ContentService.Services.Sectors.Dtos.CreateSectorModel MapToBackCreateSectorModel(this TamTech.Monshaat.POS.Web.Services.PosService.Sectors.Models.CreateSectorModel item)
        {
            return new TamTech.ContentService.Services.Sectors.Dtos.CreateSectorModel
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                IsOfficial = item.IsOfficial,
                Lang = item.Lang,
                Image = item.Image
            };
        }

        public static TamTech.ContentService.Services.Sectors.Dtos.UpdateSectorModel MapToBackUpdateSectorModel(this TamTech.Monshaat.POS.Web.Services.PosService.Sectors.Models.UpdateSectorModel item)
        {
            return new TamTech.ContentService.Services.Sectors.Dtos.UpdateSectorModel
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
                Image = item.Image
            };
        }
    }
}
