using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.ContentService.Core.Domain.Models.Results;
using TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Pages.Mapper;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Pages.Enums;
using TamTechSDK.Common.Services.ContentService.Pages.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Pages
{
    public class DirectPagesService : BaseDirectService, TamTechSDK.Common.Services.ContentService.Pages.IPageService
    {
        #region Props  
        private readonly TamTech.ContentService.Services.Pages.IPageService _pageService;
        #endregion


        #region Ctors
        public DirectPagesService(TamTech.ContentService.Services.Pages.IPageService pageService)
        {
            _pageService = pageService;
        }
        #endregion









        #region {Public Pages}  
        public async Task<PageDto> GetPublicBySlugAsync(string slug)
        {
            var backendpage = await _pageService.GetPublicBySlugAsync(slug);
            if (backendpage == null) return null;
            var page = backendpage?.MapToFrontendDto();
            if (backendpage.Type == (int)PageTypeEnum.Html)
                page.HtmlContent = ((TamTech.ContentService.Services.Pages.Dtos.HtmlPageDto)backendpage).Content;
            else
                page.SectionsContent = ((TamTech.ContentService.Services.Pages.Dtos.SectionsPageDto)backendpage).Content;
            return page;
        }

        //public async Task<IRequestProviderResult<PageDto>> GetPublicBySlugAsync(string slug)
        //{ 
        //     var result = await _pageService.GetPublicBySlugAsync(slug);
        //    return ReturnResult(result?.MapToFrontendDto()); 
        //}

        public async Task<IRequestProviderResult<PageSummary>> GetPublicPageSummaryByIdAsync(Guid id)
        {
            var result = await _pageService.GetPublicByIdAsync(id);
            return ReturnResult(result?.MapToPageSummaryFrontend());
        }

        public async Task<IRequestProviderResult<HtmlPage>> GetPublishedHtmlPageByIdAsync(Guid id)
        {
            var htmlPage = await _pageService.GetPublishedHtmlByIdAsync(id);
            return ReturnResult(htmlPage?.MapToFrontendDto());
        }


        public async Task<IRequestProviderResult<SectionsPage>> GetPublishedSectionsPageByIdAsync(Guid id)
        {
            var sectionsPage = await _pageService.GetPublishedSectionsByIdAsync(id);
            return ReturnResult(sectionsPage?.MapToFrontendDto());
        }


        public async Task<IRequestProviderResult<PageSummary>> GetPublishedBySettingIdAsync(int settingId)
        {
            var result = await _pageService.GetPublishedBySettingIdAsync(settingId);
            return ReturnResult(result?.MapToPageSummaryFrontend());
        }

        public async Task<IRequestProviderResult<HtmlPage>> GetPublishedHtmlBySettingIdAsync(int settingId)
        {
            var htmlPage = await _pageService.GetPublishedHtmlBySettingIdAsync(settingId);
            return ReturnResult(htmlPage?.MapToFrontendDto());
        }


        public async Task<IRequestProviderResult<SectionsPage>> GetPublishedSectionsBySettingIdAsync(int settingId)
        {
            var sectionsPage = await _pageService.GetPublishedSectionsBySettingIdAsync(settingId);
            return ReturnResult(sectionsPage?.MapToFrontendDto());
        }
        #endregion




        #region {Pages Manager} 

        #region {Get}  
        public async Task<IRequestProviderResult<HtmlPage>> GetHtmlPageByIdAsync(Guid id, string lang)
        {
            TamTech.ContentService.Services.Pages.Dtos.HtmlPageDto service = await _pageService.GetHtmlPageByIdAsync(id, lang);
            return ReturnResult(service?.MapToFrontendDto());
        }


        public async Task<IRequestProviderResult<SectionsPage>> GetSectionsPageByIdAsync(Guid id, string lang)
        {
            TamTech.ContentService.Services.Pages.Dtos.SectionsPageDto service = await _pageService.GetSectionsPageByIdAsync(id, lang);
            return ReturnResult(service?.MapToFrontendDto());
        }


        /*public async Task<IRequestProviderResult<List<PageDto>>> GetAllAsync(string lang)
        {
            IEnumerable<TamTech.ContentService.Services.Pages.Dtos.PageDto> result = await _pageService.GetAllExceptSoftDeletedAsync(lang);
            List<PageDto> pages = result != null ? result.Select(m => m?.MapToFrontendDto()).ToList() : new List<PageDto>();
            return ReturnResult(pages);
        }*/


        public async Task<IRequestProviderResult<PagesList>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang)
        {


            var result = await _pageService.GetAllExceptSoftDeletedAsync(pagination.MapToBackendPaginationModel(), searchParams, sorting.MapToBackendSortingModel(), lang);

            PagesList model = new PagesList
            {
                Data = result.Data != null ? result.Data.Select(m => m.MapToFrontendDto()).ToList() : new List<PageDto>(),
                Pagination = result.Pagination?.MapToForntEndPagination()
            };

            return ReturnResult(model);

        }


        #endregion


        #region { Create / Edit / Delete / Publish } 

        #region Html Page
        public async Task<IRequestProviderResult<Guid>> CreateHtmlPageAsync(CreateHtmlPageDto model)
        {
            IReturnResultModel<Guid> result = await _pageService.CreateAsync(model?.MapToBackendDto());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> EditHtmlPageAsync(EditHtmlPageDto model)
        {
            IReturnResultModel<bool> result = await _pageService.EditAsync(model?.MapToBackendDto());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> PublishHtmlPageAsync(PublishDTO data)
        {
            IReturnResultModel<bool> result = await _pageService.PublishHtmlPageAsync(data?.MapToBackend());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> DeleteHtmlPageAsync(Guid id)
        {
            IReturnResultModel<bool> result = await _pageService.SoftDeleteHtmlPageAsync(id);
            return MapRequestProviderResult(result);
        }

        #endregion

        #region Sections Page

        public async Task<IRequestProviderResult<Guid>> CreateSectionsPageAsync(CreateSectionsPageDto model)
        {
            IReturnResultModel<Guid> result = await _pageService.CreateAsync(model?.MapToBackendDto());
            return MapRequestProviderResult(result);

        }

        public async Task<IRequestProviderResult<bool>> EditSectionsPageAsync(EditSectionsPageDto model)
        {
            IReturnResultModel<bool> result = await _pageService.EditAsync(model?.MapToBackendDto());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> PublishSectionsPageAsync(PublishDTO data)
        {
            IReturnResultModel<bool> result = await _pageService.PublishSectionsPageAsync(data?.MapToBackend());
            return MapRequestProviderResult(result);
        }
        public async Task<IRequestProviderResult<bool>> DeleteSectionsPageAsync(Guid id)
        {
            IReturnResultModel<bool> result = await _pageService.SoftDeleteSectionsPageAsync(id);
            return MapRequestProviderResult(result);
        }



        #endregion


        #endregion

        #endregion










    }
}
/*
           public async Task<IRequestProviderResult<HtmlPage>> GetHtmlPageBySlugAsync(string slug)
   {
       IRequestProviderResult<HtmlPage> _resultModel = new RequestProviderResult<HtmlPage>();

       var result = await _pageService.GetPublicDynamicBySlugAsync(slug);

   }

   public async Task<IRequestProviderResult<SectionsPage>> GetSectionsPageBySlugAsync(string slug)
   {
       throw new NotImplementedException();
   }
    */


/* public async Task<IRequestProviderResult<dynamic>> GetPublicDynamicByIdAsync(Guid id)
{
IRequestProviderResult<dynamic> _resultModel = new RequestProviderResult<dynamic>();
var result = await _pageService.GetPublicDynamicByIdAsync(id);
try
{
    if (result != null && result.Id != null)
    {
        _resultModel.Success = true;
    }
}
catch (Exception ex)
{
    _resultModel.Success = false;
} 
_resultModel.Data = result;
return _resultModel;
} */
