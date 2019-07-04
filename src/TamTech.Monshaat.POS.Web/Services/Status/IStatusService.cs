using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.SelectList;
using TamTechSDK.Common.Services.Status.Models;

namespace TamTechSDK.Common.Services.Status
{
    public interface IStatusService
    {
        #region Public  Services 

        #endregion


        #region Services Manager

        #region Get

        Task<List<SelectListItemModel>> GetAllSelectListAsync(string lang);


        Task<List<StatusDto>> GetAllAsync(string lang); 
        #endregion


        #region   Create / Edit / Delete


        #endregion



        #endregion
    }
}
