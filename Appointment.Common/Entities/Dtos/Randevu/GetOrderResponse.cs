using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Entities.Dtos.Randevu
{
    public class GetOrderResponse
    {
        public Guid rowGuid { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string orderNumber { get; set; }
        public string floor { get; set; }
        public string waitedPersonCount { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
    }
}
