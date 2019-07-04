using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Services.PosService.Directory.Models;
using TamTechSDK.Common.Services.PosService.PosService.Models;

namespace TamTechSDK.Common.Services.PosService.Directory
{
   public interface IDirectoryServices
    {

        Task<PosDto> GetPublishedBySlugAsync(string slug);

        Task<PagedResultModel<List<PosDto>>> FindAsync(PosFilters model);

        Task<int> GetCountOfPublishedAsync(string lang);
    }
}
