using System;
using business_layer;
using NUnit.Framework;

namespace business_layer_test
{
    public class ComplextTypeTests
    {
        [Test]
        public void NestedClass()
        {
            string input = @"{
              ""Nested1"": {
                ""SomeString"": ""somestring"",
                ""SomeInt"": 42,
                ""SomeDouble"": 42.5,
                ""SomeDateTime"": ""2021-04-02T09:00:34""
              },
              ""Nested2"": {
                ""SomeString"": ""somestring"",
                ""SomeInt"": 42,
                ""SomeDouble"": 42.5,
                ""SomeDateTime"": ""2021-04-02T09:00:34""
              }
            }";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new() {
                Nested1 = new() {
                    SomeString = ""somestring"",
                    SomeInt = 42,
                    SomeDouble = 42.5,
                    SomeDateTime = DateTime.Parse(""2021-04-02T09:00:34"")
                },
                Nested2 = new() {
                    SomeString = ""somestring"",
                    SomeInt = 42,
                    SomeDouble = 42.5,
                    SomeDateTime = DateTime.Parse(""2021-04-02T09:00:34"")
                }
            }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
    }
}