using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace NorthEntityConsole_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            const string input = "there are 32 kids in this class, and 31 kids in that one";
            // Split on one or more non-digit characters.
            string[] numbers = Regex.Split(input, @"\D+");
            var resultArray = Regex.Split(input, @"[^0-9\.]+")
                .Where(c => c != "." && c.Trim() != "");

            foreach (var value in resultArray)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine(resultArray.Count());
            Console.ReadLine();
        }
    }
}
