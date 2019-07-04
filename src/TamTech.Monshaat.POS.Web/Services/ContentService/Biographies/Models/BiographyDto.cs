using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Biographies.Models
{
    public class BiographyDto
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Lang { get; set; }

        public string GenericField { get; set; }

        public string Description { get; set; }
    }
}
