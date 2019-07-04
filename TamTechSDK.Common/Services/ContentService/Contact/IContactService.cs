using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.Filter;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Contact.Models;

namespace TamTechSDK.Common.Services.ContentService.Contact
{
    public interface IContactService
    {

        Task<IRequestProviderResult<bool>> ReplayAsync(ReplayContactUsModel model);

        Task<ContactDto> GetByIdAndSetStatusAsync(Guid id, string lang);
        Task<ContactDto> GetByIdExceptSoftDeletedAsync(Guid id, string lang);

        Task<PagedResultModel<List<ContactDto>>> GetExceptSoftDeletedAsync(DTFilter model);
        
        Task<IRequestProviderResult<Guid>> CreateAsync(CreateModel model);

        Task<IRequestProviderResult<bool>> RemoveReplayAsync(Guid id);
    }
}
