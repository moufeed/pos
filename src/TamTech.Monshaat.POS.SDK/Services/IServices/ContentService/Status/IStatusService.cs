using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.Services.ContentService.Status.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Status
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
