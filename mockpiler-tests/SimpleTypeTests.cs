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
            string input = @"{}";
            string actual = Mockpiler.ExecuteMockpile(input);
            string expected = "{}";
            // TestHelper.AssertEqualNoWhitepace(expected, actual);
            Assert.Fail();
        }

        [Test]
        public void SingleDateTimeExactMatch()
        {
            string input = @"{}";
            string actual = Mockpiler.ExecuteMockpile(input);
            string expected = "{}";
            // TestHelper.AssertEqualNoWhitepace(expected, actual);
            Assert.Fail();
        }
        
        [Test]
        public void AllSimpleTypesExactMatch()
        {
            string input = @"{}";
            string actual = Mockpiler.ExecuteMockpile(input);
            string expected = "{}";
            // TestHelper.AssertEqualNoWhitepace(expected, actual);
            Assert.Fail();
        }

    }
}