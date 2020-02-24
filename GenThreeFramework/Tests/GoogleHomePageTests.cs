using GenThreeFramework.Helpers;
using GenThreeFramework.PageObjects;
using NUnit.Framework;

namespace GenThreeFramework.Tests
{
    public class GoogleHomePageTests
    {
        DriverHelper driverHelper;
        GoogleHomePage page;

        [SetUp]
        public void Setup()
        {
            driverHelper = new DriverHelper();
            page = new GoogleHomePage(driverHelper);
            page.StartPage();
        }

        [TestCase("un text")]
        public void SearchText(string text)
        {
            page.SearchText(text);
            driverHelper.PerformVisualAssertion(TestContext.CurrentContext.Test.MethodName);
        }

        [TearDown]
        public void TearDown()
        {
            driverHelper.Close();
        }
    }
}
