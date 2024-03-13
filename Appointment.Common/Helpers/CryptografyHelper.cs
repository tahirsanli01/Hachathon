using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Helpers
{
    public static class CryptografyHelper
    {
        public static string StringToEncoding(string strGiris)
        {
            string sonuc = "";
            if (strGiris == "" || strGiris == null)
            {
                throw new ArgumentNullException("Şifrelenecek veri yok.");
            }
            else
            {
                byte[] aryKey = Encoding.ASCII.GetBytes("123456781234567812345678");
                byte[] aryIV = Encoding.ASCII.GetBytes("12345678");
                TripleDESCryptoServiceProvider dec = new TripleDESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, dec.CreateEncryptor(aryKey, aryIV), CryptoStreamMode.Write);
                StreamWriter writer = new StreamWriter(cs);
                writer.Write(strGiris);
                writer.Flush();
                cs.FlushFinalBlock();
                writer.Flush();
                sonuc = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length).Replace("+","*").Replace("/","_");
                writer.Dispose();
                cs.Dispose();
                ms.Dispose();
            }
            return sonuc;
        }

        public static string StringToDecoding(string strGiris)
        {
            string strSonuc = "";
            if (strGiris == "" || strGiris == null)
            {
                throw new ArgumentNullException("Şifrelenecek veri yok.");
            }
            else
            {
                byte[] aryKey = Encoding.ASCII.GetBytes("123456781234567812345678");
                byte[] aryIV = Encoding.ASCII.GetBytes("12345678");
                TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream(Convert.FromBase64String(strGiris.Replace("*", "+").Replace("_", "/")));
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(aryKey, aryIV), CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(cs);
                strSonuc = reader.ReadToEnd();
                reader.Dispose();
                cs.Dispose();
                ms.Dispose();
            }
            return strSonuc;
        }
    }
}
