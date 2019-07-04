using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort ;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Testimonials.Models;

namespace TamTechSDK.Common.Services.ContentService.Testimonials
{
    public class TestimonialsServices : ITestimonialsServices
    {
        public Task<IRequestProviderResult<Guid>> CreateAsync(CreateTestimonialDto model)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> EditAsync(UpdateTestimonialDto model)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<TestimonialsList>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<TestimonialDto>> GetByIdAsync(Guid id, string lang)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<List<TestimonialDto>>> GetPublicListAsync(bool sortManually = false)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO data)
        {
            throw new NotImplementedException();
        }
    }
}
