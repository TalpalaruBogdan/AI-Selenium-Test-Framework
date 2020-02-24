using GenThreeFramework.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace GenThreeFramework.PageObjects
{
    public class GoogleHomePage
    {
        DriverHelper DriverHelper;
        const string URL = "https://www.google.com";

        public GoogleHomePage(DriverHelper driverHelper)
        {
            this.DriverHelper = driverHelper;
            PageFactory.InitElements(DriverHelper.driver, this);
        }

        [FindsBy(How = How.Name, Using = "q")]
        IWebElement searchInput;

        public void StartPage()
        {
            DriverHelper.Initialize(URL);
        }

        public void SearchText(string text)
        {
            searchInput.SendKeys(text + Keys.Enter);
        }
    }
}
