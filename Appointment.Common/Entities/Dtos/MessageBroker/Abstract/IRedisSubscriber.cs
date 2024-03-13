using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Entities.Dtos.MessageBroker.Abstract
{
    public interface IRedisSubscriber<Resp, Req>
    {
        IApiResponse<Resp> DoWork(Req req);
    }
}
