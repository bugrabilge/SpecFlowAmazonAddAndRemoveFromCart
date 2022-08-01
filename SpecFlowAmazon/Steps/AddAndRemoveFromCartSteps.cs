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
    public class AddAndRemoveFromCartSteps
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        [Given(@"I am on the purchase page of the product named Hobbit")]
        public void GivenIAmOnThePurchasePageOfTheProductNamedHobbit()
        {
            //web driver instance
            _driver = new ChromeDriver();

            _wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(5));

            //url launch
            _driver.Navigate().GoToUrl(Constant.ProductUrl);

            //accepting cookies
            _driver.FindElement(By.Id(Constant.AcceptCookies)).Click();

            Assert.That(_driver.FindElement(By.Id(Constant.SatinAlButton)).Displayed);
        }

        [Given(@"I click the Add To Cart button")]
        public void GivenIClickTheAddToCartButton()
        {
            //adding product to the cart
            _driver.FindElement(By.Id(Constant.AddToCartButton)).Click();
        }

        [Given(@"In the window that opens, I click the go to cart button")]
        public void GivenInTheWindowThatOpensIClickTheGoToCartButton()
        {
            //go to cart
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(Constant.AyrintilarButton)));
            _driver.FindElement(By.Id(Constant.GoToCartButton)).Click();
        }

        [When(@"I click the delete button on the opened page")]
        public void WhenIClickTheDeleteButtonOnTheOpenedPage()
        {
            //removing product from cart
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(Constant.SubtotalAmount)));
            _driver.FindElement(By.XPath(Constant.RemoveProductFromCartButton)).Click();
        }

        [Then(@"the product named Hobbit should be removed from the cart")]
        public void ThenTheProductNamedHobbitShouldBeRemovedFromTheCart()
        {
            Assert.That(_driver.FindElement(By.Id(Constant.YourCartIsEmpty)).Displayed);
            
            //quit browser
            _driver.Close();
        }

    }
}
