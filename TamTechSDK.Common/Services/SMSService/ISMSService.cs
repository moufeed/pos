using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.SMS.Models;

namespace TamTechSDK.Common.Services.SMS
{
    /// <summary>
    /// To be moved to separated SMS Messaging Service
    /// </summary>
    public interface ISMSService
    { 
        Task SendAsync(SMSModel model);

        Task<IRequestProviderResult<List<Smslite>>> GetSmsMessages();
        Task<IRequestProviderResult<Smslite>> getSmsByIdAsync(string id);
    }
}
