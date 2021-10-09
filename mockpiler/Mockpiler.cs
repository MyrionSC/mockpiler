using System;
using System.Collections.Generic;
using System.Linq;
using mockpiler.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mockpiler
{
    public static class Mockpiler
    {
        public static string StartMockpile(string jsonString)
        {
            return Mockpile(JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString));
        }

        public static string Mockpile(object input)
        {
            return input switch {
                JObject jObject => Mockpile(jObject),
                JArray jArray => Mockpile(jArray),
                JValue jValue => Mockpile(jValue),
                bool l => Mockpile(l),
                long l => Mockpile(l), // gets sent to double for some reason, which works
                double d => Mockpile(d),
                DateTime dt => Mockpile(dt),
                string str => Mockpile(str),
                _ => throw new Exception($"Mockpiler hit default with object of type {input.GetType()}")
            };
        }

        public static string Mockpile(Dictionary<string, object> input)
        {
            List<string> resultList = input.Select(pair => $"{CaseHelper.TitleCaseDashUnderscore(pair.Key)} = {Mockpile(pair.Value)}").ToList();
            return $"new()\n{{\n{string.Join(",\n", resultList)}\n}}";
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

        public static string Mockpile(JArray input)
        {
            List<string> resultList = input.Select(Mockpile).ToList();
            return $"new[] {{\n{string.Join(",\n", resultList)}\n}}";
        }

        public static string Mockpile(bool input)
        {
            return input ? "true" : "false";
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