using mockpiler;
using NUnit.Framework;

namespace business_layer_test
{
    public class OuterArrayTests
    {
        [Test]
        public void EmptyOuterArray()
        {
            string input = @"[]";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new [] { }"; 
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
        
        [Test]
        public void OuterArrayWithStrings()
        {
            string input = @"[""string1"",""string2"",  ""string3""]";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new [] { ""string1"", ""string2"", ""string3"" }"; 
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
        
        [Test]
        public void OuterArrayWithInts()
        {
            string input = @"[1, 2, 3]";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new [] {1, 2, 3}"; 
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
        
        [Test]
        public void OuterArrayWithObjects()
        {
            string input = @"[
                {
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
                }
            ]";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new [] {
                new() {
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
                }
            }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
        
        [Test]
        public void OuterArrayOfArrays()
        {
            string input = @"[
                [1,2,3],
                [""string1"",""string2"",  ""string3""]
            ]";
            string actual = Mockpiler.StartMockpile(input);
            string expected = @"new [] {
                new [] {1, 2, 3},
                new [] { ""string1"", ""string2"", ""string3"" }
            }";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
        
    }
}