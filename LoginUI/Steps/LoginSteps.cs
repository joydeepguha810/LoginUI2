using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowTestProject.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver _driver;

        [Given(@"the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            // Setup WebDriverManager to automatically manage ChromeDriver
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://practice.expandtesting.com/login");
        }

        [When(@"the user enters valid credentials")]
        public void WhenTheUserEntersValidCredentials()
        {
            _driver.FindElement(By.Id("username")).SendKeys("practice");
            _driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
        }

        [When(@"the user clicks the Login button")]
        public void WhenTheUserClicksTheLoginButton()
        {
            _driver.FindElement(By.Id("loginButton")).Click();
        }

        [Then(@"the user should be redirected to the homepage")]
        public void ThenTheUserShouldBeRedirectedToTheHomepage()
        {
            var expectedUrl = "https://practice.expandtesting.com/home"; // Adjust if needed
            var actualUrl = _driver.Url;
            
            if (!actualUrl.Contains(expectedUrl))
            {
                throw new Exception($"Login failed. Expected URL to contain: {expectedUrl}");
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}
