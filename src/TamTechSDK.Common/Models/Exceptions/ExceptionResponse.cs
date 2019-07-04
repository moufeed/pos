using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Models.Exceptions
{
    public class ExceptionResponse
    {
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionType { get; set; }
        public string StackTrace { get; set; }
        public ExceptionResponse InnerException { get; set; }
    }
}
