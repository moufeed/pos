using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Models.Portal.Contactus
{
    public class ContactusVM
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string CompanyName { get; set; }

        public string Location { get; set; }

        public List<IFormFile> Attachments { get; set; }

        public int TypeId { get; set; }

        public int? CityId { get; set; }

        public int? CountryId { get; set; }

        public int? RegionId { get; set; }

        public string Notes { get; set; }

        public string GenericField { get; set; }

    }
}
