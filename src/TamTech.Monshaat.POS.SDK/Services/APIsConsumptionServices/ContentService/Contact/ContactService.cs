using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Contact.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.ContactUs;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.ContactUs.Models;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Contact
{
    public class ContactService : BaseAPIService, IContactService
    {
        #region prop                                 
        private readonly IContactUsApiSettings _apiSettings;
        #endregion

        #region ctor
        public ContactService(IRequestProvider requestProvider , IContactUsApiSettings apiSettings) : base(requestProvider)
        {        
            _apiSettings = apiSettings;
        }
        #endregion

        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreateModel model)
        {
            return await ReqProvider.PostAsync<Guid, CreateModel>(_apiSettings.CreateEndpoint, model);
        }

        #region Manager
        public async Task<IRequestProviderResult<ContactDto>> GetByIdAndSetStatusAsync(Guid id, string lang)
        {

            return await ReqProvider.GetAsync<ContactDto, List<object>>(_apiSettings.GetByIdAndSetStatusEndpoint, new List<object> { id, lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<ContactDto>> GetByIdExceptSoftDeletedAsync(Guid id, string lang)
        {
            return await ReqProvider.GetAsync<ContactDto, List<object>>(_apiSettings.GetByIdExceptSoftDeletedEndpoint, new List<object> { id, lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<PagedResultModel<List<ContactDto>>>> GetExceptSoftDeletedAsync(DTFilter model)
        {
            return await ReqProvider.GetAsync<PagedResultModel<List<ContactDto>>, DTFilter>(_apiSettings.GetExceptSoftDeletedEndpoint, model, PassParamsBy.Body);
        }

        public async Task<IRequestProviderResult<bool>> RemoveReplayAsync(Guid id)
        {
            return await ReqProvider.PostAsync<bool, DeleteModel<Guid>>(_apiSettings.RemoveReplayEndpoint, new DeleteModel<Guid>(id));
        }

        public async Task<IRequestProviderResult<bool>> ReplayAsync(ReplayContactUsModel model)
        {
            return await ReqProvider.PostAsync<bool, ReplayContactUsModel>(_apiSettings.ReplayEndpoint, model);
        }
        #endregion
         
    }
}