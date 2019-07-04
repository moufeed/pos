using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Shared.Biography;
using TamTechSDK.Common.Models.Languages;

namespace TamTech.Monshaat.POS.Web.Models.Portal.Partials
{
    public class HeaderVm
    {
        public HeaderVm(List<SlugModel> Slugs, BiographyInfoVm BiographyInfo)
        {
            this.BiographyInfo = BiographyInfo;
            this.Slugs = Slugs;
        }


        public BiographyInfoVm BiographyInfo { get; set; }

        public List<SlugModel> Slugs { get; set; }
    }
}
