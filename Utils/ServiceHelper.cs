using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onliner.Utils
{
    class ServiceHelper
    {
        private static readonly Random _random = new Random();

        public static string ConvertRGBToHex(string rjb)
        {
            string[] numbers = rjb.Replace("rgba(", "").Replace(")", "").Split(",");

            int r = Int32.Parse(numbers[0].Trim());
            int g = Int32.Parse(numbers[1].Trim());
            int b = Int32.Parse(numbers[2].Trim());

            return string.Format("#{0:X2}{1:X2}{2:X2}", r, g, b);
        } 

        public static double ConvertPriceToDouble(string price)
        {
            return double.Parse(ParsingHelper.ParsePrice(price), new CultureInfo("en-US"));
        }

        public static string GenerateRandomValue(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            var stringsChar = new char[length];
            
            for (int i = 0; i < length; i++)
            {
                stringsChar[i] = chars[_random.Next(chars.Length)];
            }
            return new string (stringsChar);
        }
    }
}
