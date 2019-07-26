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
/*
 *   {
      if (settings != null)
      {
          if (settings.EvaluationTimeOnSeconds > 0)
              EvaluationTimeOnSeconds = settings.EvaluationTimeOnSeconds;
          if (settings.MinimumSecondsBetweenFailureNotifications > 0)
              MinimumSecondsBetweenFailureNotifications = settings.MinimumSecondsBetweenFailureNotifications;
          if (settings.HealthChecks?.Count > 0)
          {
              HealthChecks = new List<HealthCheckSettings>();
              foreach (var item in settings.HealthChecks)
              {
                  HealthChecks.Add(new HealthCheckSettings(item));
              }  
          }
      }

  }
  public HealthChecksUISettings()
  { }
  public int EvaluationTimeOnSeconds { get; set; } = 3600;
  public int MinimumSecondsBetweenFailureNotifications { get; set; } = 1800;
  public List<HealthCheckSettings> HealthChecks { get; set; } = new List<HealthCheckSettings>
  {
        new HealthCheckSettings()
  };


  public string GeTUriForApp()
  {
      if (HealthChecks!= null && HealthChecks.Count == 1)
      {
         return HealthChecks[0].Uri;
      }
      var healthCheck = HealthChecks.FirstOrDefault(x => !x.Uri.Contains("http"));
      if (healthCheck != null)
      {
          return healthCheck.Uri;
      }
      return new HealthCheckSettings().Uri;
  }
}
public  class HealthCheckSettings
{
  public HealthCheckSettings(string name, string uri)
  {
      Name = name;
      Uri = uri;
  }   public HealthCheckSettings( )
  {    
  }

  public HealthCheckSettings(HealthCheckSettings settings)
  {
      if (settings != null)
      {
          if (!string.IsNullOrWhiteSpace( settings.Name  ))
              Name = settings.Name;
          if (!string.IsNullOrWhiteSpace(settings.Uri))
              Uri = settings.Uri;     
      }

  }
  public string Name { get; set; } =  "APP"; 
  public string Uri { get; set; } = "api/Health";

}
 * */
