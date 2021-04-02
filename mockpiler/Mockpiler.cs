using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace business_layer
{
    public static class Mockpiler
    {
        public static string Mockpile(object input)
        {
            switch (input) {
                case string str:
                    return Mockpile(str);
                default:
                    return "default hit";
            }
        }

        public static string Mockpile(string input)
        {
            return $"\"{input}\"";
        }
        
        public static string Mockpile(Dictionary<string, object> input)
        {
            string res = "{\n\t";
            foreach (KeyValuePair<string,object> pair in input) {
                res += $"{pair.Key} = {Mockpile(pair.Value)}\n";
            }
            res += "\n}";
            return res;
        }
        
        public static string ExecuteMockpile(string input)
        {
            Dictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(input);
            return Mockpile(dict);
        }
    }

    public class SomeClass
    {
        public string La { get; set; }
    }
}
