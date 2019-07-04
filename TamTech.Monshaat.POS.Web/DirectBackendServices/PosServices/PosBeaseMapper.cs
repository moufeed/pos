using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices
{
    public static class PosBeaseMapper
    {


        public static TamTechSDK.Common.Services.PosService.PosService.Models.PosBaseDto MapToForntPosBaseDto(this TamTech.ContentService.Services.POSs.Models.POSDto item)
        {
            return new TamTechSDK.Common.Services.PosService.PosService.Models.PosBaseDto
            {
                Name = item.Name,
                Lang = item.Lang,
                TypeId = item.TypeId,
                VendorId = item.VendorId,
                About = item.About,
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Price = item.Price,
                Published = item.Published,
                SectorId = item.SectorId,
                Slug = item.Slug,
                Tags = item.Tags,
                SectorName = item.SectorName,
                ClientId = item.ClientId,
                CreatedDate = item.CreatedDate,
                CreatorUserId = item.CreatorUserId,
                Id = item.Id,
                TypeName = item.TypeName,
                Locked = item.Locked,
                ModifiedDate = item.ModifiedDate,
                ModifierUserId = item.ModifierUserId,
                StatusId = item.StatusId,
                StatusName = item.StatusName,
                StatusOptions = item.StatusOptions,
                VendorName = item.VendorName,
                OtherSector = item.OtherSector,
                Notes = item.Notes,
                Actionable = item.Actionable
            };
        }


        public static TamTechSDK.Common.Services.PosService.PosService.Models.PosDto MapToForntPosDto(this TamTech.ContentService.Services.POSs.Models.POSDetailedDto item)
        {
            return new TamTechSDK.Common.Services.PosService.PosService.Models.PosDto
            {
                Name = item.Name,
                Lang = item.Lang,
                TypeId = item.TypeId,
                VendorId = item.VendorId,
                About = item.About,
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Price = item.Price,
                Published = item.Published,
                SectorId = item.SectorId,
                Slug = item.Slug,
                Tags = item.Tags,
                SectorName = item.SectorName,
                ClientId = item.ClientId,
                CreatedDate = item.CreatedDate,
                CreatorUserId = item.CreatorUserId,
                Id = item.Id,
                Images = item.Images,
                TypeName = item.TypeName,
                Locked = item.Locked,
                ModifiedDate = item.ModifiedDate,
                ModifierUserId = item.ModifierUserId,
                StatusId = item.StatusId,
                StatusName = item.StatusName,
                StatusOptions = item.StatusOptions,
                VendorName = item.VendorName,
                OtherSector = item.OtherSector,
                VendorPhone = item.VendorPhone,
                VendorWebsite = item.VendorWebsite,
                Notes = item.Notes,
                Actionable = item.Actionable,
                Specifications = item.Specifications != null ? item.Specifications.Select(el => el.MapToForntSpecifications()).ToList() : new List<TamTechSDK.Common.Services.PosService.PosService.Models.SpecificationDto>(),
                StatusHistories = item.StatusHistories?.Select(el => el.MapToPOSStatusHistoryDto()).ToList()
            };
        }

        public static TamTechSDK.Common.Services.PosService.PosService.Models.SpecificationDto MapToForntSpecifications(this TamTech.ContentService.Services.POSs.Models.SpecificationDto item)
        {
            return new TamTechSDK.Common.Services.PosService.PosService.Models.SpecificationDto
            {
                AttId = item.AttId,
                AttName = item.AttName,
                InputType = item.InputType,
                Value = item.Value,
                Values = item.Values
            };
        }


        public static TamTech.ContentService.Services.Shared.Models.SetActionModel MapToBackUpdatePOSStatus(this TamTechSDK.Common.Services.PosService.PosService.Models.UpdatePOSStatus item)
        {
            return new ContentService.Services.Shared.Models.SetActionModel
            {
                ActionId = item.ActionId,
                Notes = item.Notes,
                Id = item.POSId,
                Lang = item.Lang
            };
        }

        public static TamTechSDK.Common.Services.Shared.Models.ProcessActionModel MapToFrontProcessActionModel(this TamTech.ContentService.Services.Shared.Models.ProcessActionModel item)
        {
            return new TamTechSDK.Common.Services.Shared.Models.ProcessActionModel
            {
                ActionId = item.ActionId,
                Name = item.Name,
                NoteMandatory = item.NoteMandatory
            };
        }


        public static TamTechSDK.Common.Services.PosService.PosService.Models.POSStatusHistoryDto MapToPOSStatusHistoryDto(this TamTech.ContentService.Services.POSs.Models.POSStatusHistoryDto item)
        {
            return new TamTechSDK.Common.Services.PosService.PosService.Models.POSStatusHistoryDto
            {
                Id = item.Id,
                ActionId = item.ActionId,
                CurrentStatusId = item.CurrentStatusId,
                PreviousStatusId = item.PreviousStatusId,
                RequestId = item.RequestId,
                UserId = item.UserId,
                ActionName = item.ActionName,
                CurrentStatusName = item.CurrentStatusName,
                Notes = item.Notes,
                PreviousStatusName = item.PreviousStatusName,
                ProcessDate = item.ProcessDate
            };
        }
    }
}
