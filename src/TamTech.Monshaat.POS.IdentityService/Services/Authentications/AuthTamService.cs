using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.IdentityService.Models;
using TamTech.Monshaat.POS.MCIServices;

namespace TamTech.Monshaat.POS.IdentityService.Services
{
    public class AuthTamService : IAuthTamService
    {     
        #region Props     
        private readonly IMCIADServices _mCIADServices;
        #endregion


        #region Ctors
        public AuthTamService(IMCIADServices mCIADServices)
        {
            _mCIADServices = mCIADServices;       
        }
        #endregion

        public async Task<AuthTamResultModel> LoginAsync(LoginTamModel model)
        {
            var request = await _mCIADServices.AuthenticateByAD(new MCIServices.Models.ADUserModel
            {
                Username = model.Username,
                Password = model.Username
            }); 

           var result =  new AuthTamResultModel { Successed = true };
             if (!request.Success || !request.Data.AuthResult)
             {
                 result.Successed = false;
             }

            return result;
        }



     
    }
}
