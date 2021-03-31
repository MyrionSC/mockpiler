using System;
using NUnit.Framework;

namespace business_layer_test
{
    public static partial class TestHelper
    {
        public static void AssertEqualNoWhitepace(string expected, string actual)
        {
            string expectedClean = expected.Replace(" ", String.Empty).Replace("\n", String.Empty);
            string actualClean = actual.Replace(" ", String.Empty).Replace("\n", String.Empty);
            Assert.AreEqual(expectedClean, actualClean);
        }
    }
}