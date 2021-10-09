using mockpiler;
using mockpiler.Helpers;
using NUnit.Framework;

namespace business_layer_test
{
    public class CaseHelperTests
    {
        [Test]
        public void TitleCaseDashDenotesFollowingUppercase()
        {
            string actual = CaseHelper.TitleCaseDashUnderscore("here-we_go");
            string expected = "HereWeGo";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
        
        [Test]
        public void TitleCaseUnderscoreDenotesFollowingUppercase()
        {
            string actual = CaseHelper.TitleCaseDashUnderscore("here_we_go");
            string expected = "HereWeGo";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
        
        [Test]
        public void TitleCaseUppercaseFirst()
        {
            string actual = CaseHelper.TitleCaseDashUnderscore("herewego");
            string expected = "Herewego";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
        
        [Test]
        public void TitleCaseShouldNotChangeWhenNoUppercase()
        {
            string actual = CaseHelper.TitleCaseDashUnderscore("Herewego");
            string expected = "Herewego";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
        
        [Test]
        public void TitleCaseAlreadyShouldStaySame()
        {
            string actual = CaseHelper.TitleCaseDashUnderscore("HereWeGo");
            string expected = "HereWeGo";
            TestHelper.AssertEqualNoWhitepace(expected, actual);
        }
    }
}