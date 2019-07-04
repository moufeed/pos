using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Pages.Models;

namespace TamTechSDK.Common.Services.ContentService.Pages
{
    public interface IPageService
    {

        #region {Public Pages}   

        //Task<IRequestProviderResult<PageDto>> GetPublicBySlugAsync(string slug);
        Task<PageDto> GetPublicBySlugAsync(string slug);

        Task<IRequestProviderResult<PageSummary>> GetPublicPageSummaryByIdAsync(Guid id);

        Task<IRequestProviderResult<HtmlPage>> GetPublishedHtmlPageByIdAsync(Guid id);


        Task<IRequestProviderResult<SectionsPage>> GetPublishedSectionsPageByIdAsync(Guid id);


        Task<IRequestProviderResult<PageSummary>> GetPublishedBySettingIdAsync(int settingId);


        Task<IRequestProviderResult<HtmlPage>> GetPublishedHtmlBySettingIdAsync(int settingId);


        Task<IRequestProviderResult<SectionsPage>> GetPublishedSectionsBySettingIdAsync(int settingId);
        #endregion




        #region {Pages Manager} 

        #region {Get} 

        Task<IRequestProviderResult<PagesList>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang);
        //Task<IRequestProviderResult<HtmlPage>> GetHtmlPageBySlugAsync(string slug);

        //Task<IRequestProviderResult<SectionsPage>> GetSectionsPageBySlugAsync(string slug);

        Task<IRequestProviderResult<HtmlPage>> GetHtmlPageByIdAsync(Guid id , string lang);

        Task<IRequestProviderResult<SectionsPage>> GetSectionsPageByIdAsync(Guid id, string lang); 
        #endregion


        #region { Create / Edit / Delete / Publish } 

        Task<IRequestProviderResult<Guid>> CreateHtmlPageAsync(CreateHtmlPageDto data);
 
        Task<IRequestProviderResult<Guid>> CreateSectionsPageAsync(CreateSectionsPageDto data);

        Task<IRequestProviderResult<bool>> EditHtmlPageAsync(EditHtmlPageDto data);

        Task<IRequestProviderResult<bool>> EditSectionsPageAsync(EditSectionsPageDto data);

        Task<IRequestProviderResult<bool>> DeleteHtmlPageAsync(Guid id);

        Task<IRequestProviderResult<bool>> DeleteSectionsPageAsync(Guid id);

        Task<IRequestProviderResult<bool>> PublishHtmlPageAsync(PublishDTO data);

        Task<IRequestProviderResult<bool>> PublishSectionsPageAsync(PublishDTO data);


        #endregion

        #endregion
 
    }
}
