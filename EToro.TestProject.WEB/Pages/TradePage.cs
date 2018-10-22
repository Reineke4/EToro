using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace EToro.TestProject.WEB.Pages
{
    class TradePage: BasePage
    {
        private const string DecreaseAmountButton = "//div[@data-etoro-automation-id='minus-button']";
        public const string MinAmountForCurrecyMessage = "//div[@data-ng-message='lowerThanAbsoluteMinPositionAmount']";

        public TradePage(IWebDriver driver) : base(driver)
        {
        }

        public void DecreaseCurrencyAmountToMin()
        {
            while (!IsElementDisplayed(MinAmountForCurrecyMessage))
            {
                FindElementByXPathAndClick(DecreaseAmountButton);
            }
        }

        public string GetMinCurrencyAmount()
        {
            if (!IsElementDisplayed(MinAmountForCurrecyMessage))
                throw new ApplicationException("The message with min available amount value isn't displayed");

            string messageText = FindElementsByXPathAndGetText(MinAmountForCurrecyMessage);
            Regex regex = new Regex("\\$(.+)");
            return regex.Match(messageText).Groups[1].Value.Trim();
        }
    }
}
