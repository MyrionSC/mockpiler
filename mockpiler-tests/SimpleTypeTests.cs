using System;
using business_layer;
using Newtonsoft.Json;
using NUnit.Framework;

namespace business_layer_test
{
    public class ArrayTests
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
            string input = @"{""La"": ""lo""}";
            string actual = Mockpiler.ExecuteMockpile(input);
            string expected = @"{ La = ""lo"" }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void SingleIntExactMatch()
        {
            string input = @"{}";
            string actual = Mockpiler.ExecuteMockpile(input);
            string expected = "{}";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void SingleDoubleExactMatch()
        {
            string input = @"{}";
            string actual = Mockpiler.ExecuteMockpile(input);
            string expected = "{}";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void SingleDateExactMatch()
        {
            string input = @"{}";
            string actual = Mockpiler.ExecuteMockpile(input);
            string expected = "{}";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void SingleDateTimeExactMatch()
        {
            string input = @"{}";
            string actual = Mockpiler.ExecuteMockpile(input);
            string expected = "{}";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
    }
}