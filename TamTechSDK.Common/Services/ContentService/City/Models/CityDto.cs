using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.City.Models
{
    public class CityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Published { get; set; }

        public int DisplayOrder { get; set; }
    }
}
