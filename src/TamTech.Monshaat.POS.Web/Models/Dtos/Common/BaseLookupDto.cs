using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Models.Dtos.Common
{
    public class BaseLookupDto : BaseLookupModel
    {
 
        public bool Published { get; set; }

        public bool IsOfficial { get; set; }

        public int GroupId { get; set; }

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifierUserId { get; set; }

        public string CreatorUserId { get; set; }

        public string ClientId { get; set; }

        public bool Locked { get; set; }
    }
}
