using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Entities.Dtos
{
    public class AppointmentUIDto
    {
        public int AppointmentId { get; set; }
        public Guid RowGuid { get; set; }
        public Guid OwnerRowGuid { get; set; }
        public int AppointmentTypeCode { get; set; }
        public string AppointmentTypeName { get; set; }
        public int DirectorateCode { get; set; }
        public string DirectorateName { get; set; }
        public long? ParentIdentityNumber { get; set; }
        public long IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gsm { get; set; }
        public int Status { get; set; }
        public int? OrderNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
