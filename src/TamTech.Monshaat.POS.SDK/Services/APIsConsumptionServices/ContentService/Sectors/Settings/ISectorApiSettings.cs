namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Sectors.Settings
{
    public interface ISectorApiSettings
    {

        #region Public  Sectors

        string GetPublishedBySlugEndpoint { get; }

        string GetPublishedListEndpoint { get; }

        string GetPublishedLimitedListEndpoint { get; }

        #endregion

        #region Sectors Manager

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
