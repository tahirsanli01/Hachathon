using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Entities.Dtos.Tracking
{
    public static class TrackingTypes
    {
        public static string Error { get; set; } = "Error";
        public static string Warning { get; set; } = "Warning";
        public static string Information { get; set; } = "Information";
        public static string Exception { get; set; } = "Exception";
        public static string CriticalError { get; set; } = "CriticalError";
    }
}
