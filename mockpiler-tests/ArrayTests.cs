using System;
using business_layer;
using NUnit.Framework;

namespace business_layer_test
{
    public class SimpleTypeTests
    {
        [Test]
        public void SingleArrayEmptyExactMatch()
        {
            string input = @"{}";
            string actual = Mockpiler.ExecuteMockpile(input);
            string expected = "{}";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
    }
}