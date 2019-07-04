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
    public class SectionsService : ISectionsService
    {
        public Task<IRequestProviderResult<Guid>> CreateAsync(CreateSectionDto model)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> EditAsync(UpdateSectionDto model)
        {
            throw new NotImplementedException();
        }

        public Task<List<SectionDto>> GetAllAsync(string lang)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<SectionList>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<SectionDto>> GetByIdAsync(Guid id, string lang)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<SectionDto>> GetPublicBySlugAsync(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<List<SectionDto>> GetPublicLatestSectionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<List<SectionDto>>> GetPublicListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<List<SectionDto>>> GetPublicListAsync(int takeitems)
        {
            throw new NotImplementedException();
        }

        public Task<List<SectionDto>> GetPublicMainSectionListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<SectionDto>> GetPublicMainSectionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SectionContainerDto> GetPublicSectionContainerByParentSlugAsync(string slug)
        {
            throw new NotImplementedException();
        }
         
        public Task<SectionContainerDto> GetPublicSectionWithLatestSubSectionsBySlugAsync( string slug)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO data)
        {
            throw new NotImplementedException();
        }

       
    }
}
