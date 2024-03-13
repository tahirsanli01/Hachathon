using Appointment.Common.Business.Abstract.Cache;
using Appointment.Common.Entities.Dtos;
using Appointment.Common.Entities.Dtos.Randevu;
using System.Runtime.InteropServices.ObjectiveC;
using System.Security.Cryptography;
using System.Text;

namespace Appointment.Common.Helper.OrderNumberHelper
{
    public class OrderHelper
    {
        IRedisOrderHelper5 _orderHelper5;
        Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
        public OrderHelper(IRedisOrderHelper5 orderHelper5)
        {
            _orderHelper5 = orderHelper5;
            keyValuePairs.Add(0, "A");
            keyValuePairs.Add(1, "B");
            keyValuePairs.Add(2, "C");
            keyValuePairs.Add(3, "D");
            keyValuePairs.Add(4, "E");
            keyValuePairs.Add(5, "F");
            keyValuePairs.Add(6, "G");
            keyValuePairs.Add(7, "H");
            keyValuePairs.Add(8, "I");
            keyValuePairs.Add(9, "J");
            keyValuePairs.Add(10, "K");
            keyValuePairs.Add(11, "L");
            keyValuePairs.Add(12, "M");
            keyValuePairs.Add(13, "N");
            keyValuePairs.Add(14, "O");
            keyValuePairs.Add(15, "P");
            keyValuePairs.Add(16, "R");
            keyValuePairs.Add(17, "S");
            keyValuePairs.Add(18, "T");
            keyValuePairs.Add(19, "U");
            keyValuePairs.Add(20, "V");
            keyValuePairs.Add(21, "Y");
            keyValuePairs.Add(22, "Z");

        }
        public string CreateUrlCode()
        {
            string DateString = DateTime.Now.GetHashCode().ToString();

            MD5 Hasher = MD5.Create();
            byte[] Data = Hasher.ComputeHash(Encoding.Default.GetBytes(DateString));

            StringBuilder Builder = new StringBuilder();

            foreach (var Byte in Data)
                Builder.Append(Byte.ToString("x2"));

            string result = Builder.ToString().Substring(0, 7);

            for (int i = 0; i < 3; i++)
            {
                Random Random = new Random();
                result = keyValuePairs[Random.Next() % 23] + result;
            }

            for (int i = 0; i < 3; i++)
            {
                Random Random = new Random();
                result = result + keyValuePairs[Random.Next() % 23];
            }

            return result.Substring(0, 13);
        }

        public (AppointmentRequest, string) CreateUrlCodeForRedis(AppointmentRequest appointment)
        {
            while (true)
            {
                var code = CreateUrlCode();
                if (!_orderHelper5.IsAdd(code))
                {
                    _orderHelper5.Add(code, appointment, int.MaxValue);
                    return (appointment, code);
                }
            }
        }

        public AppointmentRequest GetUrlCodeForRedis(string code)
        {

            if (_orderHelper5.IsAdd(code))
            {
                return _orderHelper5.Get<AppointmentRequest>(code);
            }
            return null;
        }

        public void DeleteUrlCodeForRedis(string code)
        {
            if (_orderHelper5.IsAdd(code))
            {
                _orderHelper5.Remove(code);
            }
        }
    }
}
