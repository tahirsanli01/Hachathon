using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Entities.Dtos.MessageBroker.Concrete
{
    public class SuccessApiResponse<T> : ApiResponse<T>
    {
        public SuccessApiResponse()
        {
            base.IsSuccess = true;
            base.Code = 0;
        }
    }
}
