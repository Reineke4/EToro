using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace EToro.TestProject.WEB.Pages
{
    class WhatchlistsPage: BasePage
    {
        private const string ClosePopUpButton = "//div[@class='inmplayer-popover-close-button']";
        private const string VisibleCurrensies = "//watchlist-item/div/div/div/span[1]";

        public WhatchlistsPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClosePopUp()
        {
            WaitForElementToBeClickable(ClosePopUpButton);
            IsElementDisplayed(ClosePopUpButton);
            FindElementByXPathAndClick(ClosePopUpButton);
        }

        public void ChooseCurrency(string currency)
        {
            List<IWebElement> currencies = FindElementsByXPath(VisibleCurrensies);
            IWebElement concreteCurrency = currencies.FirstOrDefault(el => el.Text.Equals(currencies));
            if (concreteCurrency == null)
                throw new ApplicationException($"No currentcy of: {currency} on the Whatchlists Page");
            concreteCurrency.Click();
        } 
    }
}
