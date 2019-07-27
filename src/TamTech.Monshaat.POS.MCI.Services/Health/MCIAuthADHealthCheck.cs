using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;   
using System.Threading;
using System.Threading.Tasks;     
using TamTech.Monshaat.POS.SDK.Core.Health;
using TamTech.Monshaat.POS.Web.SDK.Models.Shared;

namespace TamTech.Monshaat.POS.MCI.Services.Health
{
    public class MCIAuthADHealthCheck : BaseHealthCheck, IHealthCheck
    {

        #region Props  
        private readonly IMCIServices _mCIServices;
        #endregion

        #region Ctors  
        public MCIAuthADHealthCheck(BackendApiSettings backendApiSettings, ILogger<MCIAuthADHealthCheck> logger, IMCIServices mCIServices)
            : base(backendApiSettings, logger)
        {
            _mCIServices = mCIServices;
        }
        #endregion


        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            bool healthCheckResultHealthy = false;
            var result = _mCIServices.AuthenticateByAD(new MCI.Services.Models.ADUserModel
            {
                Username = "CheckHealth",

            }).GetAwaiter().GetResult();
            if (result?.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                healthCheckResultHealthy = true;
            }

            if (result?.Data != null)
            {
                healthCheckResultHealthy = result.Data.Status || !result.Data.Status;
            }
          

                if (healthCheckResultHealthy)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("The check ping MCI AD api indicates a healthy result."));
            }

            return Task.FromResult(
                HealthCheckResult.Unhealthy("The check ping MCI AD api indicates an unhealthy result."));
        }


    }
}
