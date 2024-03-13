using Appointment.Common.Entities.Dtos.MessageBroker.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Entities.Dtos.MessageBroker.Concrete
{
    public class ApiResponse<T> : IApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
