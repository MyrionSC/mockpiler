using System;
using mockpiler;
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
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new() {}";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
        
        [Test]
        public void InvalidJson()
        {
            string input = @"{";
            Assert.Throws<JsonSerializationException>(() => Mockpiler.StartMockpile(input));
        }

        [Test]
        public void SingleStringLowerCaseShouldBeTitleCased()
        {
            string input = @"{""some_key"": ""somestring""}";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new() { SomeKey = ""somestring"" }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
        
        [Test]
        public void SingleStringExactMatch()
        {
            string input = @"{""SomeString"": ""somestring""}";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new() { SomeString = ""somestring"" }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void StringButCouldBeInt()
        {
            string input = @"{""SomeString"": ""42""}";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new() { SomeString = ""42"" }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void SingleIntExactMatch()
        {
            string input = @"{ ""SomeInt"": 42 }";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new() { SomeInt = 42 }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void SingleDoubleExactMatch()
        {
            string input = @"{ ""SomeDouble"": 42.5 }";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new() { SomeDouble = 42.5 }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void SingleBooleanTrueExactMatch()
        {
            string input = @"{ ""SomeBool"": true }";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new() { SomeBool = true }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
        
        [Test]
        public void SingleBooleanFalseExactMatch()
        {
            string input = @"{ ""SomeBool"": false }";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new() { SomeBool = false }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void SingleDateTimeExactMatch()
        {
            string input = @"{""SomeDateTime"": ""2021-04-02T09:00:34""}";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new() { SomeDateTime = DateTime.Parse(""2021-04-02T09:00:34"") }";
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
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new() {
                SomeString = ""somestring"",
                SomeInt = 42,
                SomeDouble = 42.5,
                SomeDateTime = DateTime.Parse(""2021-04-02T09:00:34"")
            }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
        
        [Test]
        public void KeyWithNullValue()
        {
            string input = @"{
                SomeKey: null
            }";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new() {
                SomeKey = null
            }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

    }
}