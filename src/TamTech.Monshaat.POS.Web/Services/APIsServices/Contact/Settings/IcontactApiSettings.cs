using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Contact.Settings
{
    public interface IcontactApiSettings
    {

        string CreateEndpoint { get; }


        #region Manager

        string ReplayEndpoint { get; }

        string RemoveReplayEndpoint { get; }

        string GetExceptSoftDeletedEndpoint { get; }

        string GetByIdExceptSoftDeletedEndpoint { get; }

        string GetByIdAndSetStatusEndpoint { get; }

        #endregion
    }
}

 