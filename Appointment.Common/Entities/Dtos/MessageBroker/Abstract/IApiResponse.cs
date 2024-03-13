using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Entities.Dtos.MessageBroker.Abstract
{
    public interface IApiResponse<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
