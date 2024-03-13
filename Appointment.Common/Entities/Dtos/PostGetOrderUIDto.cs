using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Entities.Dtos
{
    public class PostGetOrderUIDto
    {
        public string Code { get; set; }
        public PostAppointmentProcessDto[] PostAppointmentProcessSubDto { get; set; }
    }

    public class PostAppointmentProcessDto
    {
        public DateTime AppointmentDate { get; set; }
        public string AppointmentRowGuid { get; set; } = "";
        public long DirectorateID { get; set; }
        public long TcNo { get; set; }
        public string Check_ { get; set; } = "";
        public bool Check { get { return Check_ == "on" ? true : false; } }
    }
}
