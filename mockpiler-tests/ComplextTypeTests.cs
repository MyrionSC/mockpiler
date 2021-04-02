using System;
using business_layer;
using NUnit.Framework;

namespace business_layer_test
{
    public class ComplextTypeTests
    {
        [Test]
        public void NestedClassWithSimpleTypes()
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
        
        [Test]
        public void NestedClassWithIntArray()
        {
            string input = @"{
              ""SomeIntList"": [
                    42, 24
                ]
            }";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new() {
                SomeIntList = new List<dynamic> {
                    42, 24
                }
            }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
        
        [Test]
        public void NestedClassWithStringArray()
        {
            string input = @"{
              ""SomeStringList"": [
                    ""item1"", ""item2""
                ]
            }";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new() {
                SomeStringList = new List<dynamic> {
                    ""item1"", ""item2""
                }
            }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
    }
}