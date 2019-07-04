using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Posts.Models;

namespace TamTechSDK.Common.Services.ContentService.Posts
{
    public interface IPostsService  
    {

        //Task<IRequestProviderResult<PostDto>> GetPublicBySlugAsync(string slug);
          
        //Task<IRequestProviderResult<List<PostDto>>> GetPublicListAsync();

         

        Task<List<PostDto>> GetPublicListAsync(int takeItems);

        Task<PostsList> GetPublicListAsync(PaginationModel pagination);
        Task<PostsList> GetPublicListBySectionSlugAsync(PaginationModel pagination, string slugHierarchy);


        Task<IRequestProviderResult<PostsList>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams , SortingModel sorting, string lang);

        Task<IRequestProviderResult<PostDto>> GetByIdAsync(Guid id, string lang);
 
        Task<IRequestProviderResult<Guid>> CreateAsync(CreatePostDto model);
          
        Task<IRequestProviderResult<bool>> EditAsync(UpdatePostDto model);
         
        Task<IRequestProviderResult<bool>> DeleteAsync(Guid id);

        Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO data);



        Task<PostsList> GetPublicLatestPostsAsync(PaginationModel Pagination);
        Task<PostsList> GetPublicLatestPostsBySectionSlugAsync(PaginationModel Pagination , string sectionSlug);
        Task<PostDto> GetPublicBySlugAndSectionSlugsAsync(List<string> sectionSlugs, string slug);
    }
}
