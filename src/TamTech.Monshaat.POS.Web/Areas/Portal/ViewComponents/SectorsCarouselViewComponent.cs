using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors;

namespace TamTech.Monshaat.POS.Web.Areas.Portal.ViewComponents
{
    [ViewComponent(Name = "SectorsList")]
    public class SectorsCarouselViewComponent : ViewComponent
    {

        private readonly IPOSSectorServices _sectorService;


        public SectorsCarouselViewComponent(IPOSSectorServices sectorService)
        {
            _sectorService = sectorService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var _sectors = await _sectorService.GetPublishedListAsync();
                if (_sectors != null && _sectors.Success && _sectors.Data != null)
                {
                    return View(_sectors.Data);
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View();
        }
    }
}
