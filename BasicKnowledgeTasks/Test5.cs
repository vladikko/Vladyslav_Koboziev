using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Task5
{
    public class Task5
    {
        // Den has invited some friends.His list is: s = "Fred:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull";
        //Could you make a program that
        //makes this string uppercase
        //gives it sorted in alphabetical order by last name.
        //When the last names are the same, sort them by first name.Last name and first name of a guest come in the result between parentheses separated by a comma.

        public static string Meeting(string s)
        {
            List<string> list = s.ToUpper().Split(';').Select(x => x.Split(':'))
                .Select(x => new { FirstName = x[0], LastName = x[1] }).OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
                .Select(x => $"({x.LastName}, {x.FirstName})").ToList();
            return string.Join("", list);
        }

    }
    public class Task5Tests
    {
        [Test]
        public void Test1()
        {
            string s = "Fred:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull";
            string expected = "(CORWILL, FRED)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)";
            string actual = Task5.Meeting(s);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test2()
        {
            string s = "John:Doe;Peter:Benjamin;Mary:Smith";
            string expected = "(BENJAMIN, PETER)(DOE, JOHN)(SMITH, MARY)";
            string actual = Task5.Meeting(s);
            Assert.AreEqual(expected, actual);
        }
    }
}