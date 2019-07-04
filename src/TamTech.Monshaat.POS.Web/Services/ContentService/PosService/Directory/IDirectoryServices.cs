using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Services.PosService.Directory.Models;
using TamTech.Monshaat.POS.Web.Services.PosService.PosService.Models;

namespace TamTech.Monshaat.POS.Web.Services.PosService.Directory
{
   public interface IDirectoryServices
    {

        Task<PosDto> GetPublishedBySlugAsync(string slug);

        Task<PagedResultModel<List<PosDto>>> FindAsync(PosFilters model);

        Task<int> GetCountOfPublishedAsync(string lang);
    }
}
