using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

namespace TamTechSDK.Common.Services.ServiceBus
{
    public interface IServiceBus
    {
        Task SendTopicAsync<T>(ServiceBusSettings configuration, T model);

        Task<bool> SendQueueAsync<T>(ServiceBusSettings configuration, T model);
    }
}
