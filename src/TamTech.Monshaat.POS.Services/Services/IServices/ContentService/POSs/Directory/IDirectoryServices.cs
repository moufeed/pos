using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.Slugs;
using TamTech.Monshaat.POS.Web.Services.POSs.Directory.Models;
using TamTech.Monshaat.POS.Web.Services.POSs.Models;

namespace TamTech.Monshaat.POS.Web.Services.POSs.Directory
{
   public interface IDirectoryServices
    {

        Task<IRequestProviderResult<PosDto>> GetPublishedBySlugAsync(string slug);

        Task<IRequestProviderResult<PagedResultModel<List<PosDto>>>> FindAsync(PosFilters model);

        Task<IRequestProviderResult<int>> GetCountOfPublishedAsync(string lang);
        Task<IRequestProviderResult<List<SlugModel>>> GetAllPublishedSlugsAsync();
    }
}
