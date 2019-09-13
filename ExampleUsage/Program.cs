using SecureStringCharacters;
using System;
using System.Security;

namespace ExampleUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = GetStr();
            str.ForEachChar(Console.WriteLine);
            Console.ReadKey();
        }

        private static SecureString GetStr()
        {
            var str = new SecureString();
            var chars = new[] { 'p', 'a', 's', 's', 'w', 'o', 'r', 'd' };
            foreach (var c in chars)
            {
                str.AppendChar(c);
            }

            str.MakeReadOnly();
            return str;
        }
    }
}
