using System.Linq;
using System.Threading.Tasks;       
using TamTech.Monshaat.POS.MCI.Services.Models;     
using TamTech.Monshaat.POS.Services.ExternalServices.CommercialRegister;
using TamTech.Monshaat.POS.Services.ExternalServices.CommercialRegister.Models;

namespace TamTech.Monshaat.POS.MCI.Services.Services
{
    public class CRService : ICRService
    {     
        #region Props     
        private readonly IMCIServices _mCIADServices;
        #endregion


        #region Ctors
        public CRService(IMCIServices mCIADServices)
        {
            _mCIADServices = mCIADServices;       
        }
        #endregion

        public async Task<CRIncludeNationalIdResultModel> CheckNationalIdBelongsToCR(CRIncludeNationalIdModel model)
        {
            if (string.IsNullOrWhiteSpace(model.CommercialRegister) || string.IsNullOrWhiteSpace(model.NationalId))
                return null;

            var request = await _mCIADServices.GetAllPersonsForCR(new GetAllPersonsForCRModel
            {
                CR = model.CommercialRegister
            });

            if (!request.Success || request.Data?.Persons == null || !request.Data.Status)
            {
                return new CRIncludeNationalIdResultModel(false);
            }

            PersonModel person = request.Data.Persons.FirstOrDefault(p => model.NationalId.Equals(p.National_ID));

            if (person != null && model.NationalId.Equals(person.National_ID))
            {
                return new CRIncludeNationalIdResultModel(true);
            }

            return new CRIncludeNationalIdResultModel(false);
        }





        }



     
    }
 
