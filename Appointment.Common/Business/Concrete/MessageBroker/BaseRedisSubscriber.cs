using Appointment.Common.Entities.Dtos.MessageBroker.Abstract;
using Appointment.Common.Entities.Dtos.MessageBroker.Concrete;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Appointment.Common.Business.Concrete.MessageBroker
{
    public class BaseRedisSubscriber<Response, Request> : IRedisSubscriber<Response, Request>
    {
        ISubscriber pubsub = ConnectionMultiplexer.Connect("127.0.0.1:6379").GetSubscriber();
        private string _className;


        public BaseRedisSubscriber(Type type)
        {
            _className = type.Name.Replace("Publish", "").Replace("Subscriber", "");
            pubsub.Subscribe(_className + "_Subscriber", (channel, message) =>
            {
                try
                {
                    var result = DoWork(JsonConvert.DeserializeObject<Request>(message));
                    if (result is SuccessApiResponse<Response>)
                    {
                        pubsub.PublishAsync(_className + "_Success", JsonConvert.SerializeObject(result), CommandFlags.FireAndForget);
                    }
                    else
                    {
                        pubsub.PublishAsync(_className + "_Fail", JsonConvert.SerializeObject(result), CommandFlags.FireAndForget);
                    }
                }
                catch (Exception ex)
                {
                    pubsub.PublishAsync(_className + "_Fail", JsonConvert.SerializeObject(new FailApiResponse<Response>() { Message = ex.Message }), CommandFlags.FireAndForget);
                }
            });
        }

        public virtual IApiResponse<Response> DoWork(Request req)
        {
            throw new NotImplementedException();
        }
    }
}
