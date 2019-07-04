namespace TamTechSDK.Common.Services.ContentService.Pages.Settings
{
    public interface IPageServiceSettings
    {


        #region {Public Pages}  
        
        string GetPublicDynamicBySlugAsyncEndpoint { get; }
        string GetPublicDynamicByIdAsyncEndpoint { get; }

        #endregion 




        #region {Pages Manager} 

        #region {Get} 

        string GetAsyncEndpoint { get; }  

        string GetHtmlPageBySlugAsyncEndpoint { get; }

        string GetSectionsPageBySlugAsyncEndpoint { get; }

        string GetHtmlPageByIdAsyncEndpoint { get; }

        string GetSectionsPageByIdAsyncEndpoint { get; }

        #endregion


        #region { Create / Edit / Delete / Publish } 

        string CreateHtmlPageAsyncEndpoint { get; }

        string CreateSectionsPageAsyncEndpoint { get; }

        string UpdateHtmlPageAsyncEndpoint { get; }

        string UpdateSectionsPageAsyncEndpoint { get; }

        string DeleteHtmlPageAsyncEndpoint { get; }

        string DeleteSectionsPageAsyncEndpoint { get; }

        string PublishHtmlPageAsyncEndpoint { get; }

        string PublishSectionsPageAsyncEndpoint { get; }
        #endregion

        #endregion




    }
}
