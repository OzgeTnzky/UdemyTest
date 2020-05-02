using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
namespace UdemyTest.Base
{
    public class BasePage
    {
        IWebDriver driver;
        WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            
        }

        public IWebElement FindElement(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            return driver.FindElement(by);
        }

        public void ClickElement(By by)
        {
            FindElement(by).Click();
        }

        public void SendKeys(By by, string value)
        {
            FindElement(by).SendKeys(value);
        }

        public void Element(By by)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(FindElement(by)).Build().Perform();
        }


    }
}
