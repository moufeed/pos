using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.VendorsServices.Models
{
    public class VendorDto : BaseVendorModel
    {
        public Guid Id { get; set; }

        public string StatusName { get; set; }

        public string StatusOptions { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifierUserId { get; set; }

        public string CreatorUserId { get; set; }

        public string ClientId { get; set; }

        public bool Locked { get; set; }

        public bool Activated { get; set; }

        public bool AdminActionable { get; set; }

        public string Notes { get; set; }

        public int GroupId { get; set; }
        public List<VendorStatusHistoryDto> StatusHistories { get; set; }
    }
}
