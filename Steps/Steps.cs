using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;
using UdemyTest.Base;

namespace UdemyTest.Steps
{
    [Binding]
    public sealed class Steps
    {
        public IWebDriver Driver { get; set; }
        public BasePage basePage;
        public Actions action;
        private readonly ScenarioContext context;
        public Steps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }
        [BeforeScenario]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("disable-popup-blocking");
            options.AddArgument("disable-notifications");
            options.AddArgument("test-type");
            Driver = new ChromeDriver(options);
            action = new Actions(Driver);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Driver.Navigate().GoToUrl("https://www.udemy.com/");
            basePage = new BasePage(Driver);
        }

        [Given("\"(.*)\" Kategoriler alanına tıklanır.")]
        public void Categories(string obje)
        {
            basePage.Element(By.LinkText(obje));
        }

        [Given("\"(.*)\" Yazılım Geliştirme alanına tıklanır.")]
        public void Development(string obje)
        {
            basePage.Element(By.LinkText(obje));
        }

        [Given("\"(.*)\" Yazılım Testi alanına tıklanır.")]
        public void SoftwareTesting(string obje)
        {
            basePage.Element(By.LinkText(obje));
        }

        [Given("\"(.*)\" Selenium WebDriver alanına tıklanır.")]
        public void Selenium(string obje)
        {
            basePage.Element(By.LinkText(obje));
            basePage.ClickElement(By.LinkText(obje));
        }

        [Given("\"(.*)\" eğitimi seçilir.")]
        public void Tutorial(string obje)
        {
            basePage.ClickElement(By.LinkText(obje));
        }

        [AfterScenario]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
