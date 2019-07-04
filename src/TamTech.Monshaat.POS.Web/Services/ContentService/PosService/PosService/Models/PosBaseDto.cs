using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.PosService.PosService.Models
{
   public  class PosBaseDto : BasePosModel
    {
        public string VendorName { get; set; }
        public string VendorWebsite { get; set; }
        public string VendorPhone { get; set; }
        public string TypeName { get; set; }

        public string SectorName { get; set; }

        public string StatusName { get; set; }

        public string StatusOptions { get; set; }

        public string OtherSector { get; set; }

        public Guid Id { get; set; }

        public int StatusId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifierUserId { get; set; }

        public string CreatorUserId { get; set; }

        public string ClientId { get; set; }

        public bool Locked { get; set; }

        public string Notes { get; set; }

        public bool Actionable { get; set; }
    }
}
