using System;
using business_layer;
using Newtonsoft.Json;
using NUnit.Framework;

namespace business_layer_test
{
    public class SimpleTypeTests
    {
        [Test]
        public void EmptyExactMatch()
        {
            string input = @"{}";
            string actual = Mockpiler.ExecuteMockpile(input);
            string expected = "{}";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
        
        [Test]
        public void InvalidJson()
        {
            string input = @"{";
            Assert.Throws<JsonSerializationException>(() => Mockpiler.ExecuteMockpile(input));
        }

        [Test]
        public void SingleStringExactMatch()
        {
            string input = @"{""SomeString"": ""somestring""}";
            string actual = Mockpiler.ExecuteMockpile(input);
            string expected = @"{ SomeString = ""somestring"" }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void StringButCouldBeInt()
        {
            string input = @"{""SomeString"": ""42""}";
            string actual = Mockpiler.ExecuteMockpile(input);
            string expected = @"{ SomeString = ""42"" }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void SingleIntExactMatch()
        {
            string input = @"{ ""SomeInt"": 42 }";
            string actual = Mockpiler.ExecuteMockpile(input);
            string expected = "{ SomeInt = 42 }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void SingleDoubleExactMatch()
        {
            string input = @"{ ""SomeDouble"": 42.5 }";
            string actual = Mockpiler.ExecuteMockpile(input);
            string expected = "{ SomeDouble = 42.5 }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void SingleDateTimeExactMatch()
        {
            string input = @"{""SomeDateTime"": ""2021-04-02T09:00:34""}";
            string actual = Mockpiler.ExecuteMockpile(input);
            string expected = @"{ SomeDateTime = DateTime.Parse(""2021-04-02T09:00:34"") }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
        
        [Test]
        public void AllSimpleTypesExactMatch()
        {
            string input = @"{
                ""SomeString"": ""somestring"",
                ""SomeInt"": 42,
                ""SomeDouble"": 42.5,
                ""SomeDateTime"": ""2021-04-02T09:00:34""
            }";
            string actual = Mockpiler.ExecuteMockpile(input);
            string expected = @"{
                SomeString = ""somestring"",
                SomeInt = 42,
                SomeDouble = 42.5,
                SomeDateTime = DateTime.Parse(""2021-04-02T09:00:34"")
            }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

    }
}