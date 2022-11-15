using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace ExtraTask2
{
    public class ExtraTask2
    {
        //Take the following IPv4 address: 128.32.10.1
        //This address has 4 octets where each octet is a single byte (or 8 bits).
        //1st octet 128 has the binary representation: 10000000
        //2nd octet 32 has the binary representation: 00100000
        //3rd octet 10 has the binary representation: 00001010
        //4th octet 1 has the binary representation: 00000001
        //So 128.32.10.1 == 10000000.00100000.00001010.00000001
        //Because the above IP address has 32 bits, we can represent it as the unsigned 32 bit number: 2149583361
        //Complete the function that takes an unsigned 32 bit number and returns a string representation of its IPv4 address.
        //Examples
        //2149583361 ==> "128.32.10.1"
        //32         ==> "0.0.0.32"
        //0          ==> "0.0.0.0"
        public static string UInt32ToIP(uint ip)
        {
            string binary = Convert.ToString(ip, 2);
            string binary32 = binary.PadLeft(32, '0');
            string[] octets = new string[4];
            for (int i = 0; i < 4; i++)
            {
                octets[i] = binary32.Substring(i * 8, 8);
            }
            string[] octetsDec = new string[4];
            for (int i = 0; i < 4; i++)
            {
                octetsDec[i] = Convert.ToInt32(octets[i], 2).ToString();
            }
            string ipString = string.Join(".", octetsDec);
            return ipString;
        }
    }
    public class ExtraTask2Tests
    {
        [Test]
        public void Test1()
        {
            uint ip = 2149583361;
            string expected = "128.32.10.1";
            string actual = ExtraTask2.UInt32ToIP(ip);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test2()
        {
            uint ip = 32;
            string expected = "0.0.0.32";
            string actual = ExtraTask2.UInt32ToIP(ip);
            Assert.AreEqual(expected, actual);
        }
    }
}