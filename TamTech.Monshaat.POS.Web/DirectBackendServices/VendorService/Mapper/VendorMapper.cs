using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TamTech.Monshaat.POS.Web.DirectBackendServices.VendorService.Mapper
{
    public static class VendorMapper
    {

        public static TamTech.ContentService.Services.Persons.Models.CreatePersonModel MapTobackCreatePersonModel(this TamTechSDK.Common.Services.VendorsServices.Models.CreatePersonModel item)
        {
            return new ContentService.Services.Persons.Models.CreatePersonModel
            {
                Email = item.Email,
                FirstName = item.FirstName,
                JobTitle = item.JobTitle,
                LastName = item.LastName,
                Mobile = item.Mobile,
                Vendor = item.Vendor?.MapToBackCreateVendorModel()
            };
        }


        public static TamTech.ContentService.Services.Vendors.Models.CreateVendorModel MapToBackCreateVendorModel(this TamTechSDK.Common.Services.VendorsServices.Models.CreateVendorModel item)
        {
            return new TamTech.ContentService.Services.Vendors.Models.CreateVendorModel
            {
                CommercialNo = item.CommercialNo,
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                Fax = item.Fax,
                Lang = item.Lang,
                GenericField = item.GenericField,
                MunicipalLicense = item.MunicipalLicense,
                Slug = item.Slug,
                WebsiteUrl = item.WebsiteUrl,
                Address = item.Address,
                Logo = item.Logo,
                Name = item.Name,
                Phone = item.Phone
            };
        }

        public static TamTech.ContentService.Services.Persons.Models.UpdatePersonModel MapTobackUpdatePersonModel(this TamTechSDK.Common.Services.VendorsServices.Models.UpdatePersonModel item)
        {
            return new ContentService.Services.Persons.Models.UpdatePersonModel
            {
                //Id = item.Id,
                Email = item.Email,
                FirstName = item.FirstName,
                JobTitle = item.JobTitle,
                LastName = item.LastName,
                Mobile = item.Mobile,
                Vendor = item.Vendor?.MapToBackUpdateVendorModel()
            };
        }


        public static TamTech.ContentService.Services.Vendors.Models.UpdateVendorModel MapToBackUpdateVendorModel(this TamTechSDK.Common.Services.VendorsServices.Models.UpdateVendorModel item)
        {
            return new TamTech.ContentService.Services.Vendors.Models.UpdateVendorModel
            {
                CommercialNo = item.CommercialNo,
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                Fax = item.Fax,
                Lang = item.Lang,
                GenericField = item.GenericField,
                MunicipalLicense = item.MunicipalLicense,
                Slug = item.Slug,
                WebsiteUrl = item.WebsiteUrl,
                Address = item.Address,
                Logo = item.Logo,
                Name = item.Name,
                Phone = item.Phone,
                Id = item.Id
            };
        }

        public static TamTechSDK.Common.Services.VendorsServices.Models.PersonDto MapToFrontPersonDto(this TamTech.ContentService.Services.Persons.Models.PersonDto item)
        {
            return new TamTechSDK.Common.Services.VendorsServices.Models.PersonDto
            {
                Id = item.Id,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate,
                ModifierUserId = item.ModifierUserId,
                CreatorUserId = item.CreatorUserId,
                ClientId = item.ClientId,
                Locked = item.Locked,
                //  Published = item.Published,
                FirstName = item.FirstName,
                LastName = item.LastName,
                JobTitle = item.JobTitle,
                Mobile = item.Mobile,
                Email = item.Email,
                Vendor = item.Vendor?.MapToFrontVendorDto(),
                IdentityNo = item.IdentityNo
            };
        }
        public static TamTechSDK.Common.Services.VendorsServices.Models.VendorDto MapToFrontVendorDto(this TamTech.ContentService.Services.Vendors.Models.VendorDto item)
        {
            return new TamTechSDK.Common.Services.VendorsServices.Models.VendorDto
            {
                Id = item.Id,
                StatusName = item.StatusName,
                StatusOptions = item.StatusOptions,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate,
                ModifierUserId = item.ModifierUserId,
                CreatorUserId = item.CreatorUserId,
                ClientId = item.ClientId,
                Locked = item.Locked,
                Activated = item.Acivated,
                GroupId = item.GroupId,
                Name = item.Name,
                CommercialNo = item.CommercialNo,
                MunicipalLicense = item.MunicipalLicense,
                WebsiteUrl = item.WebsiteUrl,
                Description = item.Description,
                Logo = item.Logo,
                Slug = item.Slug,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Phone = item.Phone,
                Address = item.Address,
                Fax = item.Fax,
                Lang = item.Lang,
                Notes = item.Notes,
                AdminActionable = item.AdminActionable,
                StatusHistories = item.StatusHistories?.Select(el => el.MapToVendorStatusHistoryDto()).ToList()
            };
        }


        public static TamTechSDK.Common.Services.VendorsServices.Models.VendorStatusHistoryDto MapToVendorStatusHistoryDto(this TamTech.ContentService.Services.Vendors.Models.VendorStatusHistoryDto item)
        {
            return new TamTechSDK.Common.Services.VendorsServices.Models.VendorStatusHistoryDto
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
