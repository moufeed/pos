 
using System.Threading.Tasks;     
using TamTech.Monshaat.POS.MCI.Services.Models;
using TamTech.Monshaat.POS.SDK.Services.ExternalServices.Authentications;
using TamTech.Monshaat.POS.SDK.Services.ExternalServices.Authentications.Models;

namespace TamTech.Monshaat.POS.MCI.Services.Services
{
    public class ADAuthService : IExternalAuthService
    {     
        #region Props     
        private readonly IMCIServices _mCIServices;
        #endregion


        #region Ctors
        public ADAuthService(IMCIServices mCIServices)
        {
            _mCIServices = mCIServices;       
        }
        #endregion

        public async Task<ExternalAuthResultModel> LoginAsync(ExternalLoginModel model)
        {
            var request = await _mCIServices.AuthenticateByAD(new ADUserModel
            {
                Username = model.Username,
                Password = model.Password
            }); 

           var result =  new ExternalAuthResultModel { Successed = true };
            if (!request.Success || !request.Data.AuthResult || !request.Data.Status)    
             {
                 result.Successed = false;
             }

            return result;
        }



     
    }
}
