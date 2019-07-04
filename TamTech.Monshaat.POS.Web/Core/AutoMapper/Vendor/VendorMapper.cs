using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Extensions.AutoMapper.Vendor
{
    public static class VendorMapper
    {
        public static Common.Services.VendorsServices.Models.CreatePersonModel MapVendorFormVmToCreatePersonModelWithoutAttachments(this Models.Portal.vendor.VendorFormVm item)
        {
            return new Common.Services.VendorsServices.Models.CreatePersonModel
            {
                Email = item.Email,
                FirstName = item.FirstName,
                JobTitle = item.JobTitle,
                LastName = item.LastName,
                Mobile = item.Mobile,
                Vendor = item?.MapVendorFormVmToCreateVendorModel()
            };
        }

        public static Common.Services.VendorsServices.Models.CreateVendorModel MapVendorFormVmToCreateVendorModel(this Models.Portal.vendor.VendorFormVm item)
        {
            return new Common.Services.VendorsServices.Models.CreateVendorModel
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
                Name = item.CompanyName,
                Phone = item.Phone
            };
        }

        public static Models.Portal.vendor.VendorFormVm MapToVendorFormVm(this TamTechSDK.Common.Services.VendorsServices.Models.PersonDto item)
        {
            return new Models.Portal.vendor.VendorFormVm
            {
                Id = item.Id,
                Name = item.Vendor.Name,
                CompanyName = item.Vendor.Name,
                CommercialNo = item.Vendor.CommercialNo,
                MunicipalLicense = item.Vendor.MunicipalLicense,
                WebsiteUrl = item.Vendor.WebsiteUrl,
                Description = item.Vendor.Description,
                Logo = item.Vendor.Logo,
                Slug = item.Vendor.Slug,
                VendorId = item.Vendor.Id,
                DisplayOrder = item.Vendor.DisplayOrder,
                GenericField = item.Vendor.GenericField,
                Phone = item.Vendor.Phone,
                Address = item.Vendor.Address,
                Fax = item.Vendor.Fax,
                Lang = item.Vendor.Lang,
                FirstName = item.FirstName,
                LastName = item.LastName,
                JobTitle = item.JobTitle,
                Mobile = item.Mobile,
                Email = item.Email,
                Activated = item.Vendor.Activated,
                AdminCanSetAction = item.Vendor.AdminActionable,
                VendorCanEdit = !item.Vendor.AdminActionable,
                StatusName = item.Vendor.StatusName,
                StatusOptions = item.Vendor.StatusOptions,
                Notes = item.Vendor.Notes
            };
        }



        public static Common.Services.VendorsServices.Models.UpdatePersonModel MapToUpdatePersonModel(this Models.Portal.vendor.VendorFormVm item)
        {
            return new Common.Services.VendorsServices.Models.UpdatePersonModel
            {
                Id = item.Id,
                Email = item.Email,
                FirstName = item.FirstName,
                JobTitle = item.JobTitle,
                LastName = item.LastName,
                Mobile = item.Mobile,
                Vendor = item?.MapVendorFormVmToUpdateVendorModel(),

            };
        }

        public static Common.Services.VendorsServices.Models.UpdateVendorModel MapVendorFormVmToUpdateVendorModel(this Models.Portal.vendor.VendorFormVm item)
        {
            return new Common.Services.VendorsServices.Models.UpdateVendorModel
            {
                Id = item.VendorId,
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
                Name = item.CompanyName,
                Phone = item.Phone
            };
        }



    }
}
