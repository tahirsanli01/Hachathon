using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Entities.Dtos.Randevu
{
    public class CancelResponse
    {
        public Guid rowGuid { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
    }
}
