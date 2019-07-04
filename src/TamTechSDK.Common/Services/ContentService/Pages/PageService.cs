using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests;
using TamTechSDK.Common.Services.ContentService.Pages.Settings;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Pages.Models;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;

namespace TamTechSDK.Common.Services.ContentService.Pages
{
    public class PageService : IPageService
    { 

        #region Props 
        private readonly IRequestProvider _requestProvider;
        private readonly IPageServiceSettings _backendSettings;
        #endregion


        #region Ctors
        public PageService(IRequestProvider requestProvider,
                               IPageServiceSettings backendSettings
                               )
        {
            _requestProvider = requestProvider;
            _backendSettings = backendSettings;
        }
        #endregion


        #region Services

        #region {Public Pages}   
        // TODO: language parameter not used yet    - from  dynamic to PageDto
        public async Task<IRequestProviderResult<PageDto>> GetPublicBySlugAsync(string slug)
        {
            return await _requestProvider.GetAsync<PageDto, List<string>>(_backendSettings.GetPublicDynamicBySlugAsyncEndpoint, new List<string> { slug });
        }


        /*   public async Task<IRequestProviderResult<dynamic>> GetPublicDynamicByIdAsync(Guid id)
          {
              return await _requestProvider.GetAsync<dynamic, List<Guid>>(_backendSettings.GetPublicDynamicByIdAsyncEndpoint, new List<Guid> { id });
          } */

        // TODO: language parameter not used yet
        public async Task<IRequestProviderResult<PageSummary>> GetPublicPageSummaryByIdAsync(Guid id)
        {
            return await _requestProvider.GetAsync<PageSummary, List<Guid>>(_backendSettings.GetPublicDynamicByIdAsyncEndpoint, new List<Guid> { id });
        }

        //public async Task<dynamic> GetPublicDynamicBySlugAsync(string slug)
        //{
        //    return GetDataResult(await _requestProvider.GetAsync<dynamic, List<string>>(_backendSettings.GetPublicDynamicBySlugAsyncEndpoint, new List<string> { slug }));
        //}

        #endregion




        #region {Pages Manager} 

        #region {Get} 
        public Task<IRequestProviderResult<PagesList>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang)
        {
            throw new NotImplementedException();
        }

        //public async Task<IRequestProviderResult<List<PageDto>>> GetAllAsync(string lang)
        //{
        //    return await _requestProvider.GetAsync<List<PageDto>>(_backendSettings.GetAsyncEndpoint);
        //}

        //public async Task<IRequestProviderResult<HtmlPage>> GetHtmlPageBySlugAsync(string slug)
        //{
        //    return await _requestProvider.GetAsync<HtmlPage, List<string>>(_backendSettings.GetHtmlPageBySlugAsyncEndpoint, new List<string> { slug });
        //}
        //public async Task<IRequestProviderResult<SectionsPage>> GetSectionsPageBySlugAsync(string slug)
        //{
        //    return await _requestProvider.GetAsync<SectionsPage, List<string>>(_backendSettings.GetSectionsPageBySlugAsyncEndpoint, new List<string> { slug });
        //}

        public async Task<IRequestProviderResult<HtmlPage>> GetHtmlPageByIdAsync(Guid id, string lang)
        {
            return await _requestProvider.GetAsync<HtmlPage, List<Guid>>(_backendSettings.GetHtmlPageByIdAsyncEndpoint, new List<Guid> { id });
        }

        public async Task<IRequestProviderResult<SectionsPage>> GetSectionsPageByIdAsync(Guid id, string lang)
        {
            return await _requestProvider.GetAsync<SectionsPage, List<Guid>>(_backendSettings.GetSectionsPageByIdAsyncEndpoint, new List<Guid> { id });
        }


        #endregion


        #region { Create / Edit / Delete / Publish } 

        public async Task<IRequestProviderResult<Guid >> CreateHtmlPageAsync(CreateHtmlPageDto data)
        {
            return await _requestProvider.PostAsync<Guid, CreateHtmlPageDto>(_backendSettings.CreateHtmlPageAsyncEndpoint, data);

        }
        public async Task<IRequestProviderResult<Guid>> CreateSectionsPageAsync(CreateSectionsPageDto data)
        {
            return await _requestProvider.PostAsync<Guid, CreateSectionsPageDto>(_backendSettings.CreateSectionsPageAsyncEndpoint, data);
        }
        public async Task<IRequestProviderResult<bool>> EditHtmlPageAsync(EditHtmlPageDto data)
        {
            return await _requestProvider.PostAsync<bool, EditHtmlPageDto>(_backendSettings.UpdateHtmlPageAsyncEndpoint, data);
        }
        public async Task<IRequestProviderResult<bool>> EditSectionsPageAsync(EditSectionsPageDto data)
        {
            return await _requestProvider.PostAsync<bool, EditSectionsPageDto>(_backendSettings.UpdateSectionsPageAsyncEndpoint, data);
        }
        public async Task<IRequestProviderResult<bool>> DeleteHtmlPageAsync(Guid id)
        {
            return await _requestProvider.GetAsync<bool, List<string>>(_backendSettings.DeleteHtmlPageAsyncEndpoint, new List<string> { id.ToString() });
        }
        public async Task<IRequestProviderResult<bool>> DeleteSectionsPageAsync(Guid id)
        {
            return await _requestProvider.GetAsync<bool, List<string>>(_backendSettings.DeleteSectionsPageAsyncEndpoint, new List<string> { id.ToString() });
        }
        public async Task<IRequestProviderResult<bool>> PublishHtmlPageAsync(PublishDTO data)
        {
            return await _requestProvider.GetAsync<bool, List<string>>(_backendSettings.PublishHtmlPageAsyncEndpoint, new List<string> { data.Id.ToString(), data.Lang });
        }
        public async Task<IRequestProviderResult<bool>> PublishSectionsPageAsync(PublishDTO data)
        {
            return await _requestProvider.GetAsync<bool, List<string>>(_backendSettings.PublishSectionsPageAsyncEndpoint, new List<string> { data.Id.ToString() , data.Lang });
        }

        public Task<IRequestProviderResult<PageSummary>> GetPublicPageSummaryByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<PageDto> IPageService.GetPublicBySlugAsync(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<HtmlPage>> GetPublishedPageHtmlByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<SectionsPage>> GetPublishedSectionsPageByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<HtmlPage>> GetPublishedHtmlPageByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<PageSummary>> GetPublishedBySettingIdAsync(int settingId)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<HtmlPage>> GetPublishedHtmlBySettingIdAsync(int settingId)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<SectionsPage>> GetPublishedSectionsBySettingIdAsync(int settingId)
        {
            throw new NotImplementedException();
        }










        #endregion

        #endregion

        #endregion

    }
}
