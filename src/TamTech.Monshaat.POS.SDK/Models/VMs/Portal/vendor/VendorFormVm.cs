using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.Web.SDK.Models.VMs.Portal.vendor
{

   

    public class VendorFormVm
    {
        public string Name { get; set; }


        public Guid Id { get; set; }

        public Guid VendorId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public string CommercialNo { get; set; }

        public string MunicipalLicense { get; set; }

        public string WebsiteUrl { get; set; }

        public string Description { get; set; }

        public string Logo { get; set; }

        public string Slug { get; set; }

        public int DisplayOrder { get; set; }

        public string GenericField { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Fax { get; set; }

        public string Lang { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Email { get; set; }

        public List<IFormFile> Attachments { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string POBox { get; set; }

        public int ZipCode { get; set; }

        public string StatusName { get; set; }

        public string StatusOptions { get; set; }


        public bool? Activated { get; set; }

        public bool? AdminCanSetAction { get; set; }

        public bool? VendorCanEdit { get; set; }
        public string Notes { get; set; }


    }
}
