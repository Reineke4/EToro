using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EToro.TestProject.WEB.Pages
{
    internal abstract class BasePage
    {
        private readonly IWebDriver _driver;

        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        protected void FindElementByXPathAndClick(string xPath)
        {
            _driver.FindElement(By.XPath(xPath)).Click();
        }

        protected void FindElementByXPathAndSendKeys(string xPath, string text)
        {
            _driver.FindElement(By.XPath(xPath)).SendKeys(text);
        }

        public bool IsElementDisplayed(string xPath)
        {
            try
            {
               return _driver.FindElement(By.XPath(xPath)).Displayed;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public void WaitForElementToBeClickable(string xPath)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xPath)));
        }

        protected List<IWebElement> FindElementsByXPath(string xPath)
        {
            return _driver.FindElements(By.XPath(xPath)).ToList();
        }

        protected string FindElementsByXPathAndGetText(string xPath)
        {
            return _driver.FindElement(By.XPath(xPath)).Text;
        }
    }
}
