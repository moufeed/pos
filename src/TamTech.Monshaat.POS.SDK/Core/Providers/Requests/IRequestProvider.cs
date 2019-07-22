using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;

namespace TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests
{
    public interface IRequestProvider
    { 
        Task<IRequestProviderResult<TResult>> GetAsync<TResult>(string uri ,bool hasJsonContent = false);
        Task<IRequestProviderResult<TResult>> GetAsync<TResult, TRequest>(string uri, TRequest data, PassParamsBy paramsBy, bool hasJsonContent = false);
        Task<IRequestProviderResult<TResult>> GetAsync<TResult, TRequest, THeader>(string uri, TRequest data, string hederKey, bool hasJsonContent = false);
        Task<IRequestProviderResult<TResult>> PostAsync<TResult, TRequest>(string uri, TRequest data, ICollection<string> urlParams = null, string header = "");

        Task<IRequestProviderResult<TResult>> PostAsync<TResult, TRequest>(string uri, TRequest data, Dictionary<string, string> header);

        Task<IRequestProviderResult<TResult>> PostAsync<TResult>(string uri, string data, string clientId, string clientSecret);
        Task<IRequestProviderResult<TResult>> PutAsync<TResult, TRequest>(string uri, TRequest data,  string header = "");
        Task DeleteAsync(string uri);
        Task<IRequestProviderResult<TResult>> PostMultipartContent<TResult>(string uri, MultipartFormDataContent content, string header = "");

    }


    public enum PassParamsBy
    {
        Route = 1,
        QueryString = 2,
        Body = 3
    }
}

