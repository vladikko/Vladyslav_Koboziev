using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class Task2
    {
        //first non repeating letter saving the capital
        public char FirstNonRepeatingLetter(string str)
        {
            var lower = str.ToLower();
            var first = lower.FirstOrDefault(c => lower.Count(x => x == c) == 1);
            return str[lower.IndexOf(first)];
        }
    }
    public class Task2Tests
    {
        [Test]
        public void Test1()
        {
            string str = "stress";
            char expected = 't';
            char actual = new Task2().FirstNonRepeatingLetter(str);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test2()
        {
            string str = "sTreSsFuLjObWrItInGTeStS";
            char expected = 'F';
            char actual = new Task2().FirstNonRepeatingLetter(str);
            Assert.AreEqual(expected, actual);
        }
    }
}