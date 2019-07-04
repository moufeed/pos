using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Testimonials.Models;

namespace TamTechSDK.Common.Services.ContentService.Testimonials
{
   public interface ITestimonialsServices
    {
        Task<IRequestProviderResult<List<TestimonialDto>>> GetPublicListAsync(bool sortManually = false);

        Task<IRequestProviderResult<TestimonialsList>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang);

        Task<IRequestProviderResult<Guid>> CreateAsync(CreateTestimonialDto model);

        Task<IRequestProviderResult<TestimonialDto>> GetByIdAsync(Guid id, string lang);

        Task<IRequestProviderResult<bool>> EditAsync(UpdateTestimonialDto model);

        Task<IRequestProviderResult<bool>> DeleteAsync(Guid id);

        Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO data);
    }
}
