using System;

namespace TamTech.Monshaat.POS.UploadService.Helpers
{
    public static class UnixTimeStamp
    {
        public static Int32 GetSeconds()
        {
            return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static long GetMilliSeconds()
        {
            return DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }
    }
}
