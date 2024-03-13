using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Entities.Dtos.Randevu
{
    public class RandevuResultData<T>
    {
        public int statusCode { get; set; }
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public string messageDetail { get; set; }
        public string exception { get; set; }
        public T data { get; set; }
    }
}
