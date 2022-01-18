using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onliner.Utils
{
    class ParsingHelper
    {
        public static string ParsePrice(string price)
        {
            var onlyDigitsLeft = price.Replace("р.", "");
            var replacedPointWithDot = onlyDigitsLeft.Replace(",", ".");
            var parsedStringWithTrimeSpaces = replacedPointWithDot.Trim();

            return parsedStringWithTrimeSpaces;
        }
    }
}
