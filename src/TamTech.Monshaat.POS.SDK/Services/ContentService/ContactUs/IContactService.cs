using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.ContactUs.Models;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.ContactUs
{
    public interface IContactService
    {

        Task<IRequestProviderResult<bool>> ReplayAsync(ReplayContactUsModel model);

        Task<IRequestProviderResult<ContactDto>> GetByIdAndSetStatusAsync(Guid id, string lang);
        Task<IRequestProviderResult<ContactDto>> GetByIdExceptSoftDeletedAsync(Guid id, string lang);

        Task<IRequestProviderResult<PagedResultModel<List<ContactDto>>>> GetExceptSoftDeletedAsync(DTFilter model);
        
        Task<IRequestProviderResult<Guid>> CreateAsync(CreateModel model);

        Task<IRequestProviderResult<bool>> RemoveReplayAsync(Guid id);
    }
}
