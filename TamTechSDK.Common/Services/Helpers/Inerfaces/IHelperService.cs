using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTechSDK.Common.Services.Helpers
{
    public interface IHelperService
    {
        bool IsNullOrDefault<TEntity>(TEntity model);

        //bool IsNullOrEmpty(Guid id);

        //TResult DeserializeFromObject<TResult>(dynamic inputObject);
    }
}
