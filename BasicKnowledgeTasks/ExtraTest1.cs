using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace ExtraTask1
{
    public class ExtraTask1
    {
        //Create a function that takes a positive integer and returns the next bigger number that can be formed by rearranging its digits
        //Example 1: 12 ==> 21
        //Example 2: 513 ==> 531
        //Example 3: 2017 ==> 2071
        public static int NextBiggerNumber(int n)
        {
            List<int> digits = n.ToString().Select(x => int.Parse(x.ToString())).ToList();
            int nextBiggerNumber = 0;
            for (int i = digits.Count - 1; i > 0; i--)
            {
                if (digits[i] > digits[i - 1])
                {
                    int temp = digits[i];
                    digits[i] = digits[i - 1];
                    digits[i - 1] = temp;
                    nextBiggerNumber = int.Parse(string.Join("", digits));
                    return nextBiggerNumber;
                }
            }
            return -1;
        }

    }
    public class ExtraTask1Tests
    {
        [Test]
        public void Test1()
        {
            int n = 12;
            int expected = 21;
            int actual = ExtraTask1.NextBiggerNumber(n);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test2()
        {
            int n = 602600;
            int expected = 606200;
            int actual = ExtraTask1.NextBiggerNumber(n);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test3()
        {
            int n = 654;
            int expected = -1;
            int actual = ExtraTask1.NextBiggerNumber(n);
            Assert.AreEqual(expected, actual);
        }
    }
}