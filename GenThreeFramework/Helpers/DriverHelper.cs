using GenThreeFramework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace GenThreeFramework.Helpers
{
    public class DriverHelper
    {
        public IWebDriver driver;

        public DriverHelper()
        {
            this.driver = new ChromeDriver(Configuration.ChromeDriverPath);
        }

        public void Initialize(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Configuration.ImplicitWait);
        }

        public void Close()
        {
            driver.Quit();
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public void SendText(string text, IWebElement element)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public void PerformVisualAssertion(string testCase)
        {
            Thread.Sleep(Configuration.WaitBeforeSnapshot * 1000);
            var snapshot = ((ITakesScreenshot)driver).GetScreenshot();
            FolderHelper.SavePictures(snapshot, testCase);
            ComparisonHelper.OperateComparison(Configuration.BaseSnapshotsFolder + testCase + ".png", Configuration.ComparisonSnapshotsFolder + testCase + ".png", Configuration.ImageTreshold, testCase);
        }



    }
}
