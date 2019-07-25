using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;           

namespace TamTech.Monshaat.POS.Web.SDK.Core.Extensions
{
    public static class LogExtensions
    {
        public static void LogException(this ILogger logger, Exception exception,  params object[] args)
        {
            try
            {
                string msg = "params";   
                if (args != null)
                {   
                    object[] newArgs = new object[args.Length];
                    for (int i = 0; i < args.Length; i++)
                    {
                        msg += "{" + i + "},";
                        if (args[i] != null)
                        {
                            var ser = JsonConvert.SerializeObject(args[i]);
                            var json = JsonConvert.DeserializeObject(ser);
                            newArgs[i] = json;
                        }
                    }
                    args = newArgs;
                }

                logger.LogError(2, exception, msg, args);
            }
            catch (Exception ex)
            {
                logger.LogError(2, exception, "{0},{1},{2}", args);
                logger.LogWarning(2, ex, "");
            }
        }
    }
}
