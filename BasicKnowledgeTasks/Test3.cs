using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class Task3
    {
        // digital root is the recursvive sum of all the digits in a number
        public int DigitalRoot(int n)
        {
            var sum = n.ToString().Select(x => int.Parse(x.ToString())).Sum();
            return sum > 9 ? DigitalRoot(sum) : sum;
        }

    }
    public class Task3Tests
    {
        [Test]
        public void Test1()
        {
            int n = 16;
            int expected = 7;
            int actual = new Task3().DigitalRoot(n);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test2()
        {
            int n = 493193;
            int expected = 2;
            int actual = new Task3().DigitalRoot(n);
            Assert.AreEqual(expected, actual);
        }
    }
}