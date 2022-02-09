using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Exception
{
    public class HttpResponseException: SystemException
    {
        public int Status { get; set; }
        public object Value { get; set; }
    }
}
