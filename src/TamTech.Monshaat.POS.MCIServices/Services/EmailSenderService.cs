using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.MCIServices.Models;
using TamTech.Monshaat.POS.Services.ExternalServices.CommercialRegister;
using TamTech.Monshaat.POS.Services.ExternalServices.CommercialRegister.Models;
using TamTech.Monshaat.POS.Web.Services.Email;
using TamTech.Monshaat.POS.Web.Services.Email.Models;

namespace TamTech.Monshaat.POS.MCIServices.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        #region Props     
        private readonly IMCIServices _mCIADServices;
        #endregion


        #region Ctors
        public EmailSenderService(IMCIServices mCIADServices)
        {
            _mCIADServices = mCIADServices;
        }
        #endregion


        public async Task<bool> SendAsync(EmailModel model,
                                            string userId = "",
                                            string clientId = "",
                                            List<string> userRoles = null)
        {
            var request = await _mCIADServices.SendEmail(new SendEmailModel
            {
                To = new List<string> { model.Email },
                TemplateCode = model.ReasonOfSend,
                CC = model.CC,
                BodyParameters = new List<string> { model.Message },
                Subject = model.Subject,
            });

            if (!request.Success || !request.Data.Status)
            {
                return false;
            }

            return true;
        }
    }




}

