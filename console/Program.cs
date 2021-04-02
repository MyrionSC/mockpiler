using System;
using System.IO;
using business_layer;
using Newtonsoft.Json;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1) {
                Console.WriteLine("arg1 should be filepath to json file");
                return;
            }
            
            string input = File.ReadAllText(args[0]);
            string output = Mockpiler.StartMockpile(input);
            
            // write output to stdout
            Console.Write(output);
        }
    }
}
