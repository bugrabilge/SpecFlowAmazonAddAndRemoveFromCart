using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace SpecFlowAmazon.Steps
{
    [Binding]
    public class SearchProductSteps
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private IWebElement _searchBox;


        [Given(@"I am on the Amazon website")]
        public void GivenIAmOnTheAmazonWebsite()
        {
            //web driver instance
            _driver = new ChromeDriver();

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            //url launch
            _driver.Navigate().GoToUrl(Constant.HomepageUrl);
            Assert.That(_driver.FindElement(By.Id(Constant.HomepageIcon)).Displayed);
        }

        [Given(@"Accept cookies")]
        public void GivenAcceptCookies()
        {
            _driver.FindElement(By.Id(Constant.AcceptCookies)).Click();
        }

        [Given(@"Type kitap on the search box")]
        public void GivenTypeKitapOnTheSearchBox()
        {
            _searchBox = _driver.FindElement(By.Id(Constant.SearchBox));
            _searchBox.SendKeys(Constant.SearchWord);
        }

        [Given(@"Search it")]
        public void GivenSearchİt()
        {
            _searchBox.Submit();
        }

        [Given(@"Search results are shown")]
        public void GivenSearchResultsAreShown()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(Constant.MakeASaleButton)));
        }

        [When(@"I click on the product named Hobbit")]
        public void WhenIClickOnTheProductNamedHobbit()
        {
            _driver.FindElement(By.LinkText(Constant.ProductName)).Click();
        }

        [Then(@"The purchase page of the product named Hobbit should be opened")]
        public void ThenThePurchasePageOfTheProductNamedHobbitShouldBeOpened()
        {
            Assert.That(_driver.FindElement(By.Id(Constant.SatinAlButton)).Displayed);

            //quit browser
            _driver.Close();
        }
    }
}
