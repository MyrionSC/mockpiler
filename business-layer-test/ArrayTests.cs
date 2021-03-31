using System;
using business_layer;
using NUnit.Framework;

namespace business_layer_test
{
    public class ArrayTests
    {
        [Test]
        public void EmptyExactMatch()
        {
            string input = @"{}";
            string actual = Mockpiler.Mockpile(input);
            string expected = "{}";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void SingleStringExactMatch()
        {
            string input = @"{}";
            string actual = Mockpiler.Mockpile(input);
            string expected = "{}";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void SingleIntExactMatch()
        {
            string input = @"{}";
            string actual = Mockpiler.Mockpile(input);
            string expected = "{}";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void SingleDoubleExactMatch()
        {
            string input = @"{}";
            string actual = Mockpiler.Mockpile(input);
            string expected = "{}";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void SingleDateExactMatch()
        {
            string input = @"{}";
            string actual = Mockpiler.Mockpile(input);
            string expected = "{}";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }

        [Test]
        public void SingleDateTimeExactMatch()
        {
            string input = @"{}";
            string actual = Mockpiler.Mockpile(input);
            string expected = "{}";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
    }
}