using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Helpers.Converters
{
    public interface IStringConverters
    {
        List<string> ToListString(string words, char separator = ',');
    }
}
