using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Portal.vendor;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Vendors.Models;

namespace TamTech.Monshaat.POS.Web.SDK.Core.Mappers.Vendor
{
    public static class VendorMapper
    {
        public static  CreatePersonModel MapVendorFormVmToCreatePersonModelWithoutAttachments(this  VendorFormVm item)
        {
            return new CreatePersonModel
            {
                Email = item.Email,
                FirstName = item.FirstName,
                JobTitle = item.JobTitle,
                LastName = item.LastName,
                Mobile = item.Mobile,
                Vendor = item?.MapVendorFormVmToCreateVendorModel()
            };
        }

        public static  CreateVendorModel MapVendorFormVmToCreateVendorModel(this  VendorFormVm item)
        {
            return new  CreateVendorModel
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

        public static  VendorFormVm MapToVendorFormVm(this TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Vendors.Models.PersonDto item)
        {
            return new  VendorFormVm
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



        public static  UpdatePersonModel MapToUpdatePersonModel(this  VendorFormVm item)
        {
            return new  UpdatePersonModel
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

        public static  UpdateVendorModel MapVendorFormVmToUpdateVendorModel(this  VendorFormVm item)
        {
            return new  UpdateVendorModel
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
