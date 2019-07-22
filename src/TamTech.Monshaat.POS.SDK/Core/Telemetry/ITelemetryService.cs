using System;
using System.Collections.Generic; 

namespace TamTech.Monshaat.POS.Web.SDK.Core.Telemetry
{
    public interface ITelemetryService
    {
        void TrackEvent(string eventName, Dictionary<string, string> properties);

        void TrackException(Exception exc, Dictionary<string, string> properties = null, Dictionary<string, double> metrics = null);
    }
}
