 
using System;
using System.Collections.Generic; 

namespace TamTech.Monshaat.POS.Web.SDK.Core.Telemetry
{
    public class TelemetryService : ITelemetryService
    { 
        public TelemetryService()
        {
 
        }

        public void TrackEvent(string eventName, Dictionary<string, string> properties)
        {
            throw new NotImplementedException();
        }

        public void TrackException(Exception exc, Dictionary<string, string> properties = null, Dictionary<string, double> metrics = null)
        {
            throw new NotImplementedException();
        }
    }
}
