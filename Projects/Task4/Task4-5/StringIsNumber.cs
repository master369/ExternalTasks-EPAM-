using System.Linq;

namespace Task4_5
{
    public static class StringIsNumber
    {
        public static bool IsNumber(this string str)
        {
            if (!(str[0] == '+' || char.IsDigit(str[0])))
            {
                return false;
            }

            for (int i = 1; i < str.Length; i++)
            {
                if (!char.IsDigit(str[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}