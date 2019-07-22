namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Values.Settings
{
    public interface IValueApiSettings
    {

        #region Public  Values

        string GetPublishedBySlugEndpoint { get; }

        string GetPublishedListEndpoint { get; }

        string GetPublishedLimitedListEndpoint { get; }

        #endregion

        #region Values Manager

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
