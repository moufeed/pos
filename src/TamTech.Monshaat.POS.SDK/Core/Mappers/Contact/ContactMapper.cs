using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Contact;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Portal.Contactus;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.ContactUs.Models;

namespace TamTech.Monshaat.POS.Web.SDK.Core.Mappers.Contact
{
    public static class ContactMapper
    {
        public static TamTech.Monshaat.POS.Web.SDK.Services.ContentService.ContactUs.Models.CreateModel MapToCreateModelWithoutAttachments(this ContactusVM item)
        {
            return new  CreateModel
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

        public static TamTech.Monshaat.POS.Web.SDK.Services.ContentService.ContactUs.Models.ReplayContactUsModel MapToReplyModel(this ReplayVm item)
        {
            return new  ReplayContactUsModel
            {
                Id = item.Id,
                Notes = item.Notes,
                Replay = item.Replay
            };
        }

    }
}
