namespace TamTechSDK.Common.Services.VendorsServices.Models
{
    public class BaseVendorModel
    {
        public string Name { get; set; }

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

        //    public string Mobile { get; set; }

        //    public string Email { get; set; }

        public string Lang { get; set; }
    }
}