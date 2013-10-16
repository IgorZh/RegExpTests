using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var result = new Dictionary<string, string>();

            using (StreamReader streamReader = new StreamReader("test.html"))
            {
                input = streamReader.ReadToEnd();
            }
            var startIndex = input.IndexOf("<!-- meta") + 9;
            input = input.Substring(startIndex, input.IndexOf("-->", startIndex) - startIndex);
            var regex = new Regex(@"#([a-zA-Z]+) (([a-zA-ZА-Яа-я \-]+)(\s*))");
            var res = regex.Matches(input);
            foreach (Match r in res)
            {
                result.Add(r.Groups[1].Value, r.Groups[3].Value);
            }

        }
    }
}
