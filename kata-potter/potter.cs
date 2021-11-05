using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_potter
{
    public static class PotterUtils
    {
        private const decimal BOOK_PRICE = 8;
        private const decimal FIRST_DISCOUNT = 0.95M;
        private const decimal SECOND_DISCOUNT = 0.90M;
        private const decimal THIRD_DISCOUNT = 0.80M;
        private const decimal FOURTH_DISCOUNT = 0.75M;

        private static readonly decimal[] DISCOUNTS = { 1, 0.95M, 0.90M, 0.80M, 0.75M };

        public static decimal CheckOut(int[] books)
        {
            int totalBookCount = 0;
            IDictionary<int, int> booksDict = new Dictionary<int, int>();
            foreach (int b in books)
            {
                totalBookCount++;
                if (booksDict.ContainsKey(b) == false)
                {
                    booksDict.Add(b, 1);
                }
                else
                {
                    booksDict[b]++;
                }
            }

            var bookKeys = booksDict.Keys.ToList();

            var resultDict = new Dictionary<int, int>();

            while (bookKeys.Count > 0)
            {
                var newBookKeys = new List<int>();
                int groupSize = 0;

                int i = 0;
                foreach (var key in bookKeys)
                {
                    groupSize++;
                    totalBookCount--;

                    booksDict[key]--;
                    if (booksDict[key] != 0)
                    {
                        newBookKeys.Add(key);
                    }

                    i++;
                }

                if (resultDict.ContainsKey(groupSize) == false)
                {
                    resultDict.Add(groupSize, 1);
                }
                else
                {
                    resultDict[groupSize]++;
                }

                bookKeys = newBookKeys;
            }

            if (resultDict.ContainsKey(5) && resultDict.ContainsKey(3))
            {
                int diff = Math.Min(resultDict[5], resultDict[3]);
                resultDict[5] -= diff;
                resultDict[3] -= diff;
                if (resultDict.ContainsKey(4))
                {
                    resultDict[4] += 2 * diff;
                }
                else
                {
                    resultDict.Add(4, 2 * diff);
                }
            }

            decimal totalPrice = 0;
            foreach (var kvp in resultDict)
            {
                totalPrice += BOOK_PRICE * kvp.Key * kvp.Value * DISCOUNTS[kvp.Key - 1];
            }

            return totalPrice;
        }
    }
}
