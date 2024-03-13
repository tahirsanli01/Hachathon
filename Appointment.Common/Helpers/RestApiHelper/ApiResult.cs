using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Helpers.RestApiHelper
{
    public class ApiResult
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }

    public class ApiDataResult<T>:ApiResult where T : new()
    {
        public T Data { get; set; }
    }
}
