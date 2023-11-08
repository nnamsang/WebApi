using System.Security.Cryptography;
using System.Text;

namespace WebApi.Helper
{
    public class CreateMD5
    {
        public static string GetMD5(string matKhau)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(matKhau);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }
    }
}