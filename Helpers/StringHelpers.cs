using System;
using System.Linq;
using System.Text;

namespace FenixAlliance.Tools.Helpers
{
    public class StringHelpers
    {
        public static string Base64Encode(string plainText)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
        }
        public static string Base64Decode(string base64EncodedData)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData));
        }

        public static string FirstCharToUpper(string input)
        {
            try
            {
                if (String.IsNullOrEmpty(input))
                    return String.Empty;
                else if (input.Length == 1)
                    return input.First().ToString().ToUpper();
                else
                    return input.First().ToString().ToUpper() + input.Substring(1);
            }
            catch
            {
                return null;
            }
        }
    }

    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
