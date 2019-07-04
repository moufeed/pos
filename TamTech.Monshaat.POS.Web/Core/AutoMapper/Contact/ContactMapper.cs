using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Web.Models.Admin.Contact;
using TamTechSDK.Web.Models.Portal.Contactus;

namespace TamTechSDK.Web.Extensions.AutoMapper.Contact
{
    public static class ContactMapper
    {
        public static TamTechSDK.Common.Services.ContentService.Contact.Models.CreateModel MapToCreateModelWithoutAttachments(this ContactusVM item)
        {
            return new Common.Services.ContentService.Contact.Models.CreateModel
            {
                Email = item.Email,
                FullName = item.Name,
                Mobile = item.MobileNumber,
                Phone = item.PhoneNumber,
                Message = item.Message,
                Subject = item.Subject,
                CompanyName = item.CompanyName,
                Notes = item.Notes,
                CityId = item.CityId,
                RegionId = item.RegionId,
                CountryId = item.CountryId,
                TypeId = item.TypeId,
                GenericField = item.GenericField,
            };
        }

        public static TamTechSDK.Common.Services.ContentService.Contact.Models.ReplayContactUsModel MapToReplyModel(this ReplayVm item)
        {
            return new Common.Services.ContentService.Contact.Models.ReplayContactUsModel
            {
                Id = item.Id,
                Notes = item.Notes,
                Replay = item.Replay
            };
        }

    }
}
