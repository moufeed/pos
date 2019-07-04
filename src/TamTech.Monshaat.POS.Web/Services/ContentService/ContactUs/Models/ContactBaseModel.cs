using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.ContactUs.Models
{
    public class ContactBaseModel
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }

        public string Subject { get; set; }

        public string CompanyName { get; set; }

        public string Notes { get; set; }

        public int? CityId { get; set; }

        public int? CountryId { get; set; }

        public int? RegionId { get; set; }

        public string GenericField { get; set; }

        public string CityName { get; set; }

        public string RegionName { get; set; }

        public string CountryName { get; set; }
    }
}
