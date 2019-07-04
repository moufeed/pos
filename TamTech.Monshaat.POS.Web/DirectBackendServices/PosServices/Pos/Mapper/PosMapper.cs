using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices.Pos.Mapper
{
    public static class PosMapper
    {

        public static TamTech.ContentService.Services.POSs.Models.CreatePOSModel MapToBackCreatePosModel(this TamTechSDK.Common.Services.PosService.PosService.Models.CreatePosModel item)
        {
            return new ContentService.Services.POSs.Models.CreatePOSModel
            {
                About = item.About,
                Attachments = item.Attachments != null ? item.Attachments.Select(m => m.MapToBackAttachments()).ToList() : null,
                VendorId = item.VendorId,
                Description = item.Description,
                DisplayOrder = -item.DisplayOrder,
                GenericField = item.GenericField,
                Lang = item.Lang,
                Name = item.Name,
                OtherSector = item.OtherSector,
                Price = item.Price,
                Published = item.Published,
                SectorId = item.SectorId,
                Slug = item.Slug,
                Specifications = item.Specifications?.Select(s => s.MapToBackend()).ToList(),
                Tags = item.Tags,
                TypeId = item.TypeId
            };
        }

        public static TamTech.ContentService.Services.POSs.Models.UpdatePOSModel MapToBackUpdatePosModel(this TamTechSDK.Common.Services.PosService.PosService.Models.UpdatePosModel item)
        {
            return new ContentService.Services.POSs.Models.UpdatePOSModel
            {
                About = item.About,
                Attachments = item.Attachments != null ? item.Attachments.Select(m => m.MapToBackAttachments()).ToList() : null,
                VendorId = item.VendorId,
                Description = item.Description,
                DisplayOrder = -item.DisplayOrder,
                GenericField = item.GenericField,
                Lang = item.Lang,
                Name = item.Name,
                OtherSector = item.OtherSector,
                Price = item.Price,
                Published = item.Published,
                SectorId = item.SectorId,
                Slug = item.Slug,
                Specifications = item.Specifications?.Select(s => s.MapToBackend()).ToList(),
                Tags = item.Tags,
                TypeId = item.TypeId,
                Id = item.Id,
                userId = item.userId
            };
        }


        public static TamTech.ContentService.Services.POSs.Models.SpecificationModel MapToBackend(this TamTechSDK.Common.Services.PosService.PosService.Models.SpecificationModel item)
        {
            return new ContentService.Services.POSs.Models.SpecificationModel
            {

                AttId = item.AttId,
                InputType = item.InputType,
                Values = item.Values,
            };
        }



    }
}
