using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.Slugs;
using TamTech.Monshaat.POS.Web.Models.Dtos.Sort;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Pages.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Pages;
using TamTech.Monshaat.POS.Web.Services.ContentService.Pages.Enums;
using TamTech.Monshaat.POS.Web.Services.ContentService.Pages.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Pages
{
    public class PageService : BaseAPIService, IPageService
    {
        #region prop              
        private readonly IPagesApiSettings _apiSettings;
    
        #endregion

        #region ctor
        public PageService(IRequestProvider requestProvider, IPagesApiSettings apiSettings ) : base(requestProvider)
        {          
            _apiSettings = apiSettings;
            
        }
        #endregion


        #region public 

        public async Task<IRequestProviderResult<List<SlugModel>>> GetAllPublishedSlugsAsync()
        {
            return await ReqProvider.GetAsync<List<SlugModel>>(_apiSettings.GetAllPublishedSlugsEndpoint);
        }


        public async Task<IRequestProviderResult<PageDto>> GetPublicBySlugAsync(string slug)
        {
            var request = await ReqProvider.GetAsync<PageDto, List<object>>(_apiSettings.GetPublicBySlugEndpoint, new List<object> { slug }, PassParamsBy.Route ,true);
            JsonSerializerSettings _serializerSettings = new JsonSerializerSettings();
            if (request.Success)
            {
                if (request.Data.Type == (int)PageTypeEnum.Sections)
                {
                    var _sectionsPage = JsonConvert.DeserializeObject<SectionsPage>(request.JsonContent, _serializerSettings);
                    request.Data.SectionsContent = _sectionsPage.Content;
                }
                else
                {
                    var htmlpage = JsonConvert.DeserializeObject<HtmlPage>(request.JsonContent, _serializerSettings);
                    request.Data.HtmlContent = htmlpage.Content;
                }
            }

            return request;
        }

        public async Task<IRequestProviderResult<PageSummary>> GetPublicPageSummaryByIdAsync(Guid id)
        {
            return await ReqProvider.GetAsync<PageSummary, List<object>>(_apiSettings.GetPublicPageSummaryByIdEndpoint, new List<object> { id }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<PageSummary>> GetPublishedBySettingIdAsync(int settingId)
        {
            return await ReqProvider.GetAsync<PageSummary, List<object>>(_apiSettings.GetPublishedBySettingIdEndpoint, new List<object> { settingId }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<HtmlPage>> GetPublishedHtmlBySettingIdAsync(int settingId)
        {
            return await ReqProvider.GetAsync<HtmlPage, List<object>>(_apiSettings.GetPublishedHtmlBySettingIdEndpoint, new List<object> { settingId }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<HtmlPage>> GetPublishedHtmlPageByIdAsync(Guid id)
        {
            return await ReqProvider.GetAsync<HtmlPage, List<object>>(_apiSettings.GetPublishedHtmlPageByIdEndpoint, new List<object> { id }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<SectionsPage>> GetPublishedSectionsBySettingIdAsync(int settingId)
        {
            return await ReqProvider.GetAsync<SectionsPage, List<object>>(_apiSettings.GetPublishedSectionsBySettingIdEndpoint, new List<object> { settingId }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<SectionsPage>> GetPublishedSectionsPageByIdAsync(Guid id)
        {
            return await ReqProvider.GetAsync<SectionsPage, List<object>>(_apiSettings.GetPublishedSectionsPageByIdEndpoint, new List<object> { id }, PassParamsBy.Route);
        }

        #endregion

        #region admin

        #region Get
        public async Task<IRequestProviderResult<PagesList>> GetAllAsync(DTFilter model)
        {
            
           return await ReqProvider.GetAsync<PagesList, DTFilter>(_apiSettings.GetAllEndpoint, model, PassParamsBy.Body);
          
        }

        public async Task<IRequestProviderResult<HtmlPage>> GetHtmlPageByIdAsync(Guid id, string lang)
        {
            return await ReqProvider.GetAsync<HtmlPage, List<object>>(_apiSettings.GetHtmlPageByIdEndpoint, new List<object> { id , lang }, PassParamsBy.Route);
        }

        
        public async Task<IRequestProviderResult<SectionsPage>> GetSectionsPageByIdAsync(Guid id, string lang)
        {
            return await ReqProvider.GetAsync<SectionsPage, List<object>>(_apiSettings.GetSectionsPageByIdEndpoint, new List<object> { id, lang }, PassParamsBy.Route);
        }
        #endregion

        #region Manage
        public async Task<IRequestProviderResult<Guid>> CreateHtmlPageAsync(CreateHtmlPageDto data)
        {
            return await ReqProvider.PostAsync<Guid, CreateHtmlPageDto>(_apiSettings.CreateHtmlPageEndpoint, data);
        }

        public async Task<IRequestProviderResult<Guid>> CreateSectionsPageAsync(CreateSectionsPageDto data)
        {
            return await ReqProvider.PostAsync<Guid, CreateSectionsPageDto>(_apiSettings.CreateSectionsPageEndpoint, data);
        }

       

        public async Task<IRequestProviderResult<bool>> EditHtmlPageAsync(EditHtmlPageDto data)
        {
            return await ReqProvider.PostAsync<bool, EditHtmlPageDto>(_apiSettings.EditHtmlPageEndpoint, data);
        }

        public async Task<IRequestProviderResult<bool>> EditSectionsPageAsync(EditSectionsPageDto data)
        {
            return await ReqProvider.PostAsync<bool, EditSectionsPageDto>(_apiSettings.EditSectionsPageEndpoint, data);
        }


        public async Task<IRequestProviderResult<bool>> PublishHtmlPageAsync(PublishModel data)
        {
            return await ReqProvider.PostAsync<bool, PublishModel>(_apiSettings.PublishHtmlPageEndpoint, data);
        }

        public async Task<IRequestProviderResult<bool>> PublishSectionsPageAsync(PublishModel data)
        {
            return await ReqProvider.PostAsync<bool, PublishModel>(_apiSettings.PublishSectionsPageEndpoint, data);
        }


        public async Task<IRequestProviderResult<bool>> DeleteHtmlPageAsync(Guid id)
        {
            return await ReqProvider.PostAsync<bool, DeleteModel<Guid>>(_apiSettings.DeleteHtmlPageEndpoint, new DeleteModel<Guid>(id));
        }

        public async Task<IRequestProviderResult<bool>> DeleteSectionsPageAsync(Guid id)
        {
            return await ReqProvider.PostAsync<bool, DeleteModel<Guid>>(_apiSettings.DeleteSectionsPageEndpoint, new DeleteModel<Guid>(id));
        }

       

        #endregion
        #endregion
    }
}
