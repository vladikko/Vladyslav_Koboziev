using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    public class Task4
    {
        //  Count the number of pairs in the array, the sum of which will give target
        public int CountPairs(int[] arr, int target)
        {
            var count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == target)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

    }
    public class Task4Tests
    {
        [Test]
        public void Test1()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int target = 10;
            int expected = 4;
            int actual = new Task4().CountPairs(arr, target);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test2()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int target = 20;
            int expected = 0;
            int actual = new Task4().CountPairs(arr, target);
            Assert.AreEqual(expected, actual);
        }
    }
}