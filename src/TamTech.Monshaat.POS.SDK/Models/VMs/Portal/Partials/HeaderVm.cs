using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.VMs.Shared.Biography;
using TamTech.Monshaat.POS.Web.Models.Dtos.Slugs;

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
