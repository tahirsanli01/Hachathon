using Appointment.Common.Entities.Dtos.MessageBroker.Abstract;
using Appointment.Common.Entities.Dtos.MessageBroker.Concrete;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Business.Concrete.MessageBroker
{
    public class BaseRedisPublisher<Response, Request> : IRedisPublisher<Response, Request>
    {
        ISubscriber pubsub = ConnectionMultiplexer.Connect("127.0.0.1:6379").GetSubscriber();
        private string _className;

        public delegate void CallbackPublisher(IApiResponse<Response> apiResponse);

        private CallbackPublisher _callbackPublisher;

        public BaseRedisPublisher(Type type)
        {
            _className = type.Name.Replace("Publish", "").Replace("Subscriber", "");
            pubsub.Subscribe(_className + "_Success", (channel, message) => Success(JsonConvert.DeserializeObject<SuccessApiResponse<Response>>(message)));
            pubsub.Subscribe(_className + "_Fail", (channel, message) => Fail(JsonConvert.DeserializeObject<FailApiResponse<Response>>(message)));
        }

        public virtual void Publish(Request req)
        {
            pubsub.PublishAsync(_className + "_Subscriber", JsonConvert.SerializeObject(req), CommandFlags.FireAndForget);
        }

        public virtual void Publish(Request req, CallbackPublisher callbackPublisher)
        {
            _callbackPublisher = callbackPublisher;
            pubsub.PublishAsync(_className + "_Subscriber", JsonConvert.SerializeObject(req), CommandFlags.FireAndForget);
        }

        public virtual void Success(SuccessApiResponse<Response> response)
        {
            if (_callbackPublisher != null)
            {
                _callbackPublisher(response);
            }
        }

        public virtual void Fail(FailApiResponse<Response> response)
        {
            if(_callbackPublisher!=null)
            {
                _callbackPublisher(response);
            }
        }
    }
}
