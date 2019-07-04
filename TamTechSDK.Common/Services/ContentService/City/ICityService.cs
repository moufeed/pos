using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.SelectList;
using TamTechSDK.Common.Services.ContentService.City.Models;

namespace TamTechSDK.Common.Services.ContentService.City
{
   public  interface ICityService
    {
        #region Public  Services 

        Task<List<CityDto>> GetPublicListAsync();

        #endregion


        #region Services Manager

        #region Get

        Task<List<SelectListItemModel>> GetAllListExceptSoftDeletedAsync();

        #endregion


        #region   Create / Edit / Delete


        #endregion



        #endregion

    }
}
