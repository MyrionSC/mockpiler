using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace business_layer
{
    public static class Mockpiler
    {
        public static string Mockpile(object input)
        {
            switch (input) {
                case int i:
                    return Mockpile(i);
                case long l:
                    return Mockpile(l);
                case double d:
                    return Mockpile(d);
                case DateTime dt:
                    return Mockpile(dt);
                case string str:
                    return Mockpile(str);
                default:
                    return "default hit";
            }
        }

        public static string Mockpile(DateTime input)
        {
            string isoDateStr = input.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
            return $"DateTime.Parse(\"{isoDateStr}\")";
        }
        
        public static string Mockpile(string input)
        {
            return $"\"{input}\"";
        }
        
        public static string Mockpile(double input)
        {
            return input.ToString(System.Globalization.CultureInfo.InvariantCulture); // commas as dots
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
            SomeClass sc = new SomeClass {
                SomeInt = 1,
                SomeDouble = 1.0,
                SomeDateTime = DateTime.Parse("2021-04-02T09:00:34Z")
            };
            
            Dictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(input);
            return Mockpile(dict);
        }
    }

    public class SomeClass
    {
        public string SomeString { get; set; }
        public int SomeInt { get; set; }
        public double SomeDouble { get; set; }
        public DateTime SomeDateTime { get; set; }
    }
}
