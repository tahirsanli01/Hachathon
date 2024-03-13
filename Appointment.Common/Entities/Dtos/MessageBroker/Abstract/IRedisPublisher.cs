using Appointment.Common.Entities.Dtos.MessageBroker.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Entities.Dtos.MessageBroker.Abstract
{
    public interface IRedisPublisher<Resp, Req>
    {
        void Publish(Req resp);
        void Success(SuccessApiResponse<Resp> response);
        void Fail(FailApiResponse<Resp> response);
    }
}
