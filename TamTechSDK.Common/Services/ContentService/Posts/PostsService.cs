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
    public class PostsService : IPostsService
    {
        public Task<IRequestProviderResult<Guid>> CreateAsync(CreatePostDto model)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> EditAsync(UpdatePostDto model)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<PostsList>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<PostDto>> GetByIdAsync(Guid id, string lang)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> GetPublicBySlugAndSectionSlugsAsync(List<string> sectionSlugs, string slug)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<PostDto>> GetPublicBySlugAsync(string slug)
        {
            throw new NotImplementedException();
        }

       

        public Task<PostsList> GetPublicLatestPostsAsync(PaginationModel Pagination)
        {
            throw new NotImplementedException();
        }

        

        public Task<PostsList> GetPublicLatestPostsBySectionSlugAsync(PaginationModel Pagination, string sectionSlug)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<List<PostDto>>> GetPublicListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<List<PostDto>>> GetPublicListAsync(int takeitems)
        {
            throw new NotImplementedException();
        }

        public Task<PostsList> GetPublicListAsync(PaginationModel pagination)
        {
            throw new NotImplementedException();
        }

        public Task<PostsList> GetPublicListBySectionSlugAsync(PaginationModel pagination, string slugHierarchy)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO data)
        {
            throw new NotImplementedException();
        }

        Task<List<PostDto>> IPostsService.GetPublicListAsync(int takeItems)
        {
            throw new NotImplementedException();
        }
    }
}
