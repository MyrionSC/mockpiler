using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace business_layer
{
    public static class Mockpiler
    {
        public static string StartMockpile(string jsonString)
        {
            Outer outer = new() {
                Nested1 = new() {
                    SomeString = "somestring",
                    SomeInt = 42,
                    SomeDouble = 42.5,
                    SomeDateTime = DateTime.Parse("2021-04-02T09:00:34")
                },
                Nested2 = new() {
                    SomeString = "somestring",
                    SomeInt = 42,
                    SomeDouble = 42.5,
                    SomeDateTime = DateTime.Parse("2021-04-02T09:00:34")
                }
            };

            Dictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
            return Mockpile(dict);
        }
        
        public static string Mockpile(object input)
        {
            return input switch {
                JObject jObject => Mockpile(jObject),
                Dictionary<string, object> dict => Mockpile(dict),
                long l => Mockpile(l), // gets sent to double for some reason, which works
                double d => Mockpile(d),
                DateTime dt => Mockpile(dt),
                string str => Mockpile(str),
                _ => throw new Exception($"Mockpiler hit default with object of type {input.GetType()}")
            };
        }
        
        // Nested classes come out of JsonConvert as JObject. We convert to dict and pass it along.
        public static string Mockpile(JObject input)
        {
            return Mockpile(input.ToObject<Dictionary<string, object>>());
        }
        
        public static string Mockpile(Dictionary<string, object> input)
        {
            List<string> resultList = input.Select(pair => $"{pair.Key} = {Mockpile(pair.Value)}").ToList();
            return $"new() \n{{\n\t{string.Join(",\n", resultList)}\n}}";
        }

        public static string Mockpile(double input)
        {
            return input.ToString(System.Globalization.CultureInfo.InvariantCulture); // commas as dots
        }

        public static string Mockpile(DateTime input)
        {
            return $"DateTime.Parse(\"{ input.ToString("s", System.Globalization.CultureInfo.InvariantCulture) }\")";
        }

        public static string Mockpile(string input)
        {
            return $"\"{input}\"";
        }

    }

    public class SomeClass
    {
        public string SomeString;
        public int SomeInt;
        public double SomeDouble;
        public DateTime SomeDateTime;
    }

    public class Outer
    {
        public SomeClass Nested1;
        public SomeClass Nested2;
    }
}