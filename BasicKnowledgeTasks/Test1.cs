using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class Task1
    {
        public static List<int> GetIntegersFromList(List<object> unfilteredList)
        {
            return unfilteredList.OfType<int>().ToList();
        }
    }
    public class Task1Tests
    {
        [Test]
        public void Test1()
        {
            List<object> list = new List<object>() { 1, 2, "String5", 3, 4, 5, "str1", 6, "str2", 7, 8, 9, 10, "asdf" };

            List<int> expected = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<int> actual = Task1.GetIntegersFromList(list);

            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void Test2()
        {
            List<object> list = new List<object>() { "String5", "str1", "str2", "asdf","TestString" };

            List<int> expected = new List<int>() { };

            List<int> actual = Task1.GetIntegersFromList(list);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}