using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Values.Models
{
    public class CreateValueModel : ValueModel
    {
        public bool IsOfficial { get; set; }

        public int GroupId { get; set; }
    }
}
