namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Regions.Settings
{
    public interface IRegionApiSettings
    {

        #region Public  Regions

        string GetPublishedBySlugEndpoint { get; }

        string GetPublishedListEndpoint { get; }

        string GetPublishedLimitedListEndpoint { get; }

        string GetPublishedSelectListEndpoint { get; }

        #endregion

        #region Regions Manager

        #region Get
        string GetSelectListEndpoint { get; }

        string GetAllSelectListEndpoint { get; }

        string GetByIdExceptSoftDeletedEndpoint { get; }

        string GetAllExceptSoftDeletedEndpoint { get; }

        string GetExceptSoftDeletedEndpoint { get; }

        #endregion

        #region  Publish / Create / Edit / Delete 



        string CreateEndpoint { get; }

        string EditEndpoint { get; }

        string SoftDeleteEndpoint { get; }

        string PublishEndpoint { get; }


        #endregion


        #endregion


    }
}
