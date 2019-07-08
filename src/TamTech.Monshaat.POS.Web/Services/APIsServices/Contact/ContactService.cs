using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Contact.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.ContactUs;
using TamTech.Monshaat.POS.Web.Services.ContentService.ContactUs.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Contact
{
    public class ContactService : BaseAPIService, IContactService
    {
        #region prop
        private readonly IRequestProvider _requestProvider;
        private readonly IcontactApiSettings _apiSettings;
        #endregion

        #region ctor
        public ContactService(IRequestProvider requestProvider , IcontactApiSettings apiSettings) : base(requestProvider)
        {
            _requestProvider = requestProvider;
            _apiSettings = apiSettings;
        }
        #endregion

        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreateModel model)
        {
            return await _requestProvider.PostAsync<Guid, CreateModel>(_apiSettings.CreateEndpoint, model);
        }

        #region Manager
        public async Task<IRequestProviderResult<ContactDto>> GetByIdAndSetStatusAsync(Guid id, string lang)
        {

            return await _requestProvider.GetAsync<ContactDto, List<object>>(_apiSettings.GetByIdAndSetStatusEndpoint, new List<object> { id, lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<ContactDto>> GetByIdExceptSoftDeletedAsync(Guid id, string lang)
        {
            throw new NotImplementedException();
        }

        public async Task<IRequestProviderResult<PagedResultModel<List<ContactDto>>>> GetExceptSoftDeletedAsync(DTFilter model)
        {
            throw new NotImplementedException();
        }

        public async Task<IRequestProviderResult<bool>> RemoveReplayAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IRequestProviderResult<bool>> ReplayAsync(ReplayContactUsModel model)
        {
            throw new NotImplementedException();
        }
        #endregion
         
    }
}