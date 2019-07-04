using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sliders.Models;

namespace TamTech.Monshaat.POS.Web.Models.VMs.Admin.Sliders
{
    public class UpdateSliderVm
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Key { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifierUserId { get; set; }

        public string CreatorUserId { get; set; }

        public string ClientId { get; set; }

        public bool Published { get; set; }

        public List<string> Tags { get; set; } = new List<string>();

        public string Summary { get; set; }

        public string Lang { get; set; }

        //[JsonProperty("position")]
        //public string Position { get; set; }

        [JsonProperty("items")]
        public List<UpdateSliderItemVm> Items { get; set; }
    }
}
