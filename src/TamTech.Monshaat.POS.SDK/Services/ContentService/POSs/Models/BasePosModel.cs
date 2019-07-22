using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.SDK.Services.POSs.Models
{
    public class BasePosModel
    {
        [JsonProperty("vendorid")]
        public Guid VendorId { get; set; }

        [JsonProperty("typeid")]
        public int TypeId { get; set; }

        [JsonProperty("sectorid")]
        public int? SectorId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("displayorder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("genericfield")]
        public string GenericField { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("othersector")]
         public string OtherSector { get; set; }
    }
}
