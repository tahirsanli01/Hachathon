using Appointment.Common.Business.Abstract.Cache;
using Appointment.Common.Business.Concrete.MessageBroker;
using Appointment.Common.Entities.Dtos.MessageBroker.Abstract;
using Appointment.Common.Entities.Dtos.MessageBroker.Concrete;
using Appointment.Common.Entities.Dtos.RequestNumber;
using Newtonsoft.Json;
using Sequential.Web.UI.Business.SignalR;

namespace Sequential.Web.UI.Business
{
    public class RequestNumberSubscriber : BaseRedisSubscriber<string, RequestNumber>
    {
        SequentialHub _sequentialHub;
        private readonly IRedisAuthorizedUserAccount7 _redisAuthorizedUserAccount7;
        public RequestNumberSubscriber(SequentialHub sequentialHub, IRedisAuthorizedUserAccount7 redisAuthorizedUserAccount7) : base(typeof(RequestNumberSubscriber))
        {
            _sequentialHub = sequentialHub;
            _redisAuthorizedUserAccount7 = redisAuthorizedUserAccount7;
        }

        public override IApiResponse<string> DoWork(RequestNumber req)
        {
            _sequentialHub.RequestNumber(req.BranchCode.ToString(), JsonConvert.SerializeObject(req));
            return new FailApiResponse<string>() { Message = "İşleminiz başarılı değil" };
        }
    }
}
