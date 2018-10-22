using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace EToro.TestProject.WEB.Pages
{
    class CurrencyPage: BasePage
    {
        private const string TradeButton = "//div[@automation-id='trade-button']/span[text()='Trade']";

        public CurrencyPage(IWebDriver driver) : base(driver)
        {
        }

        public void StartTrading()
        {
            FindElementByXPathAndClick(TradeButton);
        }
    }
}
