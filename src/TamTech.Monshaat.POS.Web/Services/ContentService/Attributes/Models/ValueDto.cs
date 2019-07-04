using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Attributes.Models
{
    public class ValueDto : BaseLookupDto
    {
        public int AttId { get; set; }

        public int Number { get; set; }

        public string Text { get; set; }

        public bool Checked { get; set; }

    }
}
