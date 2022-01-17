using System;
using System.Collections.Generic;


namespace Onliner.Utils
{
    public class Sorting
    {
        public bool isSortedBy(string sortingType, List<string> list)
        {

            switch (sortingType)
            {
                case "Дорогие":

                    var prices = ConvertToDouble(list);

                    for (int i = 0; i < prices.Count -1 ; i++)
                    {
                        if (prices[i] < prices[i + 1])
                        {
                            return false;
                        }
                    }
                    return true;

                default:
                    throw new ArgumentException(nameof(sortingType));
            }
        }

        private List<double> ConvertToDouble(List<string> list)
        {
            List<double> numbers = new List<double>();

            list.ForEach(el => numbers.Add(ServiceHelper.ConvertPriceToDouble(el)));
            
            return numbers;
        }
    }
}
