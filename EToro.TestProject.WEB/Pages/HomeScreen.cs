using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace EToro.TestProject.WEB.Pages
{
    internal class HomeScreen: BasePage
    {
        public const string LoginButton = "//li[@class='login']/a";

        public HomeScreen(IWebDriver driver) : base(driver)
        {
        }

        public void MoveToTheLoginPage()
        {
            FindElementByXPathAndClick(LoginButton);
        }
    }
}
