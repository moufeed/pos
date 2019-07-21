using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Status.Models;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Status
{
    public interface IStatusService
    {
        #region Public  Services 

        #endregion


        #region Services Manager

        #region Get

        Task<IRequestProviderResult<List<SelectListItemModel>>> GetAllSelectListAsync(string lang);


        Task<IRequestProviderResult<List<StatusDto>>> GetAllAsync(string lang); 
        #endregion


        #region   Create / Edit / Delete


        #endregion



        #endregion
    }
}
