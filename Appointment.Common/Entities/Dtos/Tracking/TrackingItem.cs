using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Entities.Dtos.Tracking
{
    public class TrackingItem
    {
        public int Id { get; set; }
        public string ServerName { get; set; }
        public string TypeName { get; set; }
        public string ClassName { get; set; }
        public Guid? RowGuid { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }
    }
}
