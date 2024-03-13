using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Entities.Dtos.RequestNumber
{
    public class ScreenDto
    {
        public int RowNumber { get; set; }
        public int FloorNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nullable<int> BankoNo { get; set; }
        public string ServiceType { get; set; }
        public Nullable<bool> Alert { get; set; }
        public string DirectorateName { get; set; }
    }

}
