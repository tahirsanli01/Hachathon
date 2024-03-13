using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Entities.Dtos.MessageBroker.Concrete
{
    public class FailApiResponse<T> : ApiResponse<T>
    {
        public FailApiResponse()
        {
            base.IsSuccess = false;
            base.Code = -1;
        }
    }
}
