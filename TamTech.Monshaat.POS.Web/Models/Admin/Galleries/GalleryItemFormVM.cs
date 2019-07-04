using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Web.Models.Admin.Galleries
{
    public class GalleryItemFormVM : GalleryBaseItemVM
    {

        public string MainImage { get; set; }

        public int GalleryItemType { get; set; }

        public string VideoUrl { get; set; }
    }
}
