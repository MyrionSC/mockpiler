using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mockpiler
{
    public static class Mockpiler
    {
        public static string StartMockpile(string jsonString)
        {
            Dictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
            return Mockpile(dict);
        }

        public static string Mockpile(object input)
        {
            return input switch {
                Dictionary<string, object> dict => Mockpile(dict),
                JObject jObject => Mockpile(jObject),
                JArray jArray => Mockpile(jArray),
                JValue jValue => Mockpile(jValue),
                long l => Mockpile(l), // gets sent to double for some reason, which works
                double d => Mockpile(d),
                DateTime dt => Mockpile(dt),
                string str => Mockpile(str),
                _ => throw new Exception($"Mockpiler hit default with object of type {input.GetType()}")
            };
        }

        public static string Mockpile(Dictionary<string, object> input)
        {
            List<string> resultList = input.Select(pair => $"{pair.Key} = {Mockpile(pair.Value)}").ToList();
            return $"new() \n{{\n{string.Join(",\n", resultList)}\n}}";
        }

        // Nested classes come out of JsonConvert as JObject. We convert to dict and pass it along.
        public static string Mockpile(JObject input)
        {
            return Mockpile(input.ToObject<Dictionary<string, object>>());
        }

        public static string Mockpile(JValue input)
        {
            return Mockpile(input.ToObject<object>());
        }

        // TODO: Try to guess array type from first element
        public static string Mockpile(JArray input)
        {
            List<string> resultList = input.Select(Mockpile).ToList();
            return $"new List<dynamic> {{\n{string.Join(",\n", resultList)}\n}}";
        }

        public static string Mockpile(double input)
        {
            return input.ToString(System.Globalization.CultureInfo.InvariantCulture); // commas as dots
        }

        public static string Mockpile(DateTime input)
        {
            return $"DateTime.Parse(\"{input.ToString("s", System.Globalization.CultureInfo.InvariantCulture)}\")";
        }

        public static string Mockpile(string input)
        {
            return $"\"{input}\"";
        }
    }
}