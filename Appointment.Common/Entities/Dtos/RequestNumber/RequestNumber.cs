namespace Appointment.Common.Entities.Dtos.RequestNumber
{
    public class RequestNumber
    {
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
        public string MessageType { get; set; }
        public string MessageCode { get; set; }
        public string MessageContent { get; set; }
		public string MessageContentReact { get; set; }
	}


    public class RequestCompareImage
    {
        public long Identity { get; set; }
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
    }
}
