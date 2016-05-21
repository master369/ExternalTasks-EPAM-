using System.Text;
using System.Security.Cryptography;

namespace Helpers
{
    public class MD5Hash
    {
        public static string GetMD5Hash(string str)
        {
            string hash;

            using (MD5 md5Hash = MD5.Create())
            {
                hash = _getMd5Hash(md5Hash, str);
            }

            return hash;
        }

        private static string _getMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

    }
}
