using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Services.Models;

namespace TamTechSDK.Common.Services.ContentService.Services
{
    public interface IServicesService //// 
    {

        Task<IRequestProviderResult<ServiceDto>> GetPublicBySlugAsync(string slug);

        Task<IRequestProviderResult<List<ServiceDto>>> GetPublicListAsync(bool sortManually = false);

        Task<IRequestProviderResult<List<ServiceDto>>> GetPublicListAsync(int  takeitems, bool sortManually = false);

        Task<IRequestProviderResult<List<ServiceDto>>> GetPublicListAsync(int takeItems, string section, bool sortManually = false);

        Task<PagedResultModel<List<ServiceDto>>> GetPublicListAsync(PaginationModel pagination, string section = null, SortingModel sorting = null);

        Task<IRequestProviderResult<List<ServiceDto>>> GetPublicListBySectionAsync(string section ,bool sortManually = false);

        Task<IRequestProviderResult<ServiceList>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang);

        Task<IRequestProviderResult<ServiceDto>> GetByIdAsync(Guid id, string lang);
 
        Task<IRequestProviderResult<Guid>> CreateAsync(CreateServiceDto model);
                
        Task<IRequestProviderResult<bool>> EditAsync(UpdateServiceDto model);
         
        Task<IRequestProviderResult<bool>> DeleteAsync(Guid id);

        Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO data);
    }
}
