using System;
using System.IO;
using System.Threading.Tasks;
using mockpiler;

namespace console
{
    class Program
    {
        static async Task Main(string[] args)
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