using Appointment.Common.Business.Concrete.MessageBroker;
using Appointment.Common.Entities.Dtos.MessageBroker.Concrete;
using Appointment.Common.Entities.Dtos.RequestNumber;

namespace Sequential.Handler.Business
{
    public class RequestNumberPublish : BaseRedisPublisher<string, RequestNumber>
    {
        public RequestNumberPublish() : base(typeof(RequestNumberPublish))
        {

        }
        public override void Publish(RequestNumber req)
        {
            base.Publish(req);
        }

        public override void Success(SuccessApiResponse<string> response)
        {
            base.Success(response);
        }

        public override void Fail(FailApiResponse<string> response)
        {
            base.Fail(response);
        }
    }
}
