using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Reviews.Models;

namespace TamTechSDK.Common.Services.ContentService.Reviews
{
   public interface IReviewsServices
    {
        Task<IRequestProviderResult<List<Review>>> GetAllReviewsAsync();
        Task<IRequestProviderResult<Review>> GetReviewByIdAsync(string id);
    }
}
