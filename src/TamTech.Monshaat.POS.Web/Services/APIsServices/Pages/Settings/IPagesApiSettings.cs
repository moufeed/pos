using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Pages.Settings
{
    public interface IPagesApiSettings
    {

        #region {Public Pages}   


        string GetPublicBySlugEndpoint { get; }

        string GetPublicPageSummaryByIdEndpoint { get; }

        string GetPublishedHtmlPageByIdEndpoint { get; }


        string GetPublishedSectionsPageByIdEndpoint { get; }


        string GetPublishedBySettingIdEndpoint { get; }


        string GetPublishedHtmlBySettingIdEndpoint { get; }


        string GetPublishedSectionsBySettingIdEndpoint { get; }
        #endregion




        #region {Pages Manager} 

        #region {Get} 

        string GetAllEndpoint { get; }


        string GetHtmlPageByIdEndpoint { get; }

        string GetSectionsPageByIdEndpoint { get; }
        #endregion


        #region { Create / Edit / Delete / Publish } 

        string CreateHtmlPageEndpoint { get; }

        string CreateSectionsPageEndpoint { get; }

        string EditHtmlPageEndpoint { get; }

        string EditSectionsPageEndpoint { get; }

        string DeleteHtmlPageEndpoint { get; }

        string DeleteSectionsPageEndpoint { get; }

        string PublishHtmlPageEndpoint { get; }

        string PublishSectionsPageEndpoint { get; }


        #endregion

        #endregion
    }
}
