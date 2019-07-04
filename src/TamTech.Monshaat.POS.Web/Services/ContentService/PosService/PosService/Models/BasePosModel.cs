using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.PosService.PosService.Models
{
    public class BasePosModel
    {
        public Guid VendorId { get; set; }

        public int TypeId { get; set; }

        public int? SectorId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string About { get; set; }

        public double Price { get; set; }

        public string Slug { get; set; }

        public string Tags { get; set; }

        public bool Published { get; set; }

        public int DisplayOrder { get; set; }

        public string GenericField { get; set; }

        public string Lang { get; set; }
    }
}
