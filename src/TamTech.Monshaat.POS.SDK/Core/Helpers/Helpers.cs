using Newtonsoft.Json;
using System;
using System.Linq;

namespace TamTech.Monshaat.POS.Web.SDK.Core.Helpers
{
    public class Helpers
    { 
        public static T Deserialize<T>(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return default(T);
            return JsonConvert.DeserializeObject<T>(value);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


        public static string GetFileNameFromUrl(string URl)
        {
            if (string.IsNullOrWhiteSpace(URl)) return URl;
            string _url = (URl.Contains("http://") || URl.Contains("https://")) ? URl : $"https://localhost/" + URl;
            Uri uri = new Uri(_url);
            var filename = uri.Segments.Last();
            return filename;
        }

         
    }
}
