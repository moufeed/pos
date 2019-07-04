using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Posts.Models;
using TamTechSDK.Common.Services.ContentService.Sections.Models;

namespace TamTechSDK.Common.Services.ContentService.Sections
{
    public interface ISectionsService
    {

        // Task<IRequestProviderResult<SectionDto>> GetPublicBySlugAsync(string slug);


        //  Task<IRequestProviderResult<List<SectionDto>>> GetPublicListAsync(int takeitems);

        //   Task<IRequestProviderResult<SectionContainerDto>> GetPublicSectionContainerByParentSlugAsync(string slug);

        Task<List<SectionDto>> GetPublicMainSectionsAsync();

        Task<IRequestProviderResult<List<SectionDto>>> GetPublicListAsync();

        Task<List<SectionDto>> GetPublicLatestSectionsAsync();

        Task<SectionContainerDto> GetPublicSectionWithLatestSubSectionsBySlugAsync(string slug);


        Task<List<SectionDto>> GetAllAsync(string lang);

        Task<IRequestProviderResult<SectionList>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang);

        Task<IRequestProviderResult<SectionDto>> GetByIdAsync(Guid id, string lang);

        Task<IRequestProviderResult<Guid>> CreateAsync(CreateSectionDto model);
          
        Task<IRequestProviderResult<bool>> EditAsync(UpdateSectionDto model);
         
        Task<IRequestProviderResult<bool>> DeleteAsync(Guid id);

        Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO data);

    }
}
