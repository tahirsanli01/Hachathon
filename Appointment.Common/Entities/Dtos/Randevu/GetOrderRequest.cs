using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Entities.Dtos.Randevu
{
    public class GetOrderRequest
    {
        public int DirectorateID { get; set; }
        public long IdentityNo { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
