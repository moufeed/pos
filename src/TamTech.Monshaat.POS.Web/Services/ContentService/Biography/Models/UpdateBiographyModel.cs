using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Biography.Models
{
    public class UpdateBiographyModel
    {
        public int GroupId { get; set; }

        public string Lang { get; set; }

        public List<BiographyModel> Biographies { get; set; }
    }
}
