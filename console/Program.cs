using System;
using System.IO;
using business_layer;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2) {
                Console.WriteLine("arg1 should be filepath to json file");
                return;
            }

            string input = File.ReadAllText(args[1]);
            
            string output = Mockpiler.Mockpile(input);
            
            // write output to stdout
            Console.Write(output);
        }
    }
}
