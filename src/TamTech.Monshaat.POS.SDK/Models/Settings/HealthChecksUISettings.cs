using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TamTech.Monshaat.POS.SDK.Models.Settings
{
   public  class HealthChecksUISettings
    {
      
        public HealthChecksUISettings()
        { }
        public int EvaluationTimeOnSeconds { get; set; } = 3600;
        public int MinimumSecondsBetweenFailureNotifications { get; set; } = 1800;
        public List<HealthCheckSettings> HealthChecks { get; set; } = new List<HealthCheckSettings>();
          


        public string GeTUriForApp()
        {
            if (HealthChecks!= null && HealthChecks.Count == 1)
            {
               return $"/{HealthChecks[0].Uri}";
            }
            var healthCheck = HealthChecks.FirstOrDefault(x => !x.Uri.Contains("http"));
            if (healthCheck != null)
            {
                return $"/{healthCheck.Uri}";
            }
            return $"/{new HealthCheckSettings().Uri}";
        }
    }
   public  class HealthCheckSettings
    {
        public HealthCheckSettings(string name, string uri)
        {
            Name = name;
            Uri = uri;
        }
        public HealthCheckSettings( )
        {    
        }

     
        public string Name { get; set; } =  "APP"; 
        public string Uri { get; set; } = "api/Health";

    }
}
 
