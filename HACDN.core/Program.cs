using HACDN.Wrappers;
using System;

namespace HACDN.core
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var x = new SwitchbrewWrapper();
            var p = x.GetTitlesAsync().Result;


            Console.ReadLine();
        }
    }
}
