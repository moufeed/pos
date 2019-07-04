using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Contact.Mapper
{
    public static class ContactMapper
    {


        public static TamTech.ContentService.Services.ContactsUs.Models.CreateContactUsModel mapToBackCreateContact(this TamTech.Monshaat.POS.Web.Services.ContentService.Contact.Models.CreateModel item)
        {
            return new ContentService.Services.ContactsUs.Models.CreateContactUsModel
            {
                CityId = item.CityId,
                CompanyName = item.CompanyName,
                Email = item.Email,
                CountryId = item.CountryId,
                FullName = item.FullName,
                RegionId = item.RegionId,
                Phone = item.Phone,
                Subject = item.Subject,
                Mobile = item.Mobile,
                Message = item.Message,
                Notes = item.Notes,
                TypeId = item.TypeId,
                GenericField = item.GenericField,
                Attachments = item.Attachments != null ? item.Attachments.Select(m => m.MapToBackAttachments()).ToList() : null
            };
        }

        public static TamTech.Monshaat.POS.Web.Services.ContentService.Contact.Models.ContactDto MapToFrontContactDto(this TamTech.ContentService.Services.ContactsUs.Models.ContactUsDto item)
        {
            return new TamTech.Monshaat.POS.Web.Services.ContentService.Contact.Models.ContactDto
            {
                Attachments = item.Attachments,
                Notes = item.Notes,
                CityId = item.CityId,
                CityName = item.CityName,
                CompanyName = item.CompanyName,
                CountryId = item.CountryId,
                CountryName = item.CountryName,
                CreatedDate = item.CreatedDate,
                Email = item.Email,
                FullName = item.FullName,
                GenericField = item.GenericField,
                Id = item.Id,
                Message = item.Message,
                Mobile = item.Mobile,
                ModifiedDate = item.ModifiedDate,
                Phone = item.Phone,
                RegionId = item.RegionId,
                RegionName = item.RegionName,
                Replay = item.Replay,
                StatusId = item.StatusId,
                StatusName = item.StatusName,
                Subject = item.Subject,
                TypeName = item.TypeName,
                StatusOptions = item.StatusOptions
            };
        }


        public static TamTech.ContentService.Services.ContactsUs.Models.ReplayContactUsModel MapToBackReplayModel(this TamTech.Monshaat.POS.Web.Services.ContentService.Contact.Models.ReplayContactUsModel item)
        {
            return new ContentService.Services.ContactsUs.Models.ReplayContactUsModel
            {
                Id = item.Id,
                Replay = item.Replay
            };
        }
    }
}
