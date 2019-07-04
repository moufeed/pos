using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Status.Models
{
   public  class StatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Options { get; set; }
        public string GenericField { get; set; }
        public int DisplayOrder { get; set; }
        public string Lang { get; set; }
    }
}
