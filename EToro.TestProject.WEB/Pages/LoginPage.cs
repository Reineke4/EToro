using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace EToro.TestProject.WEB.Pages
{
    internal class LoginPage: BasePage
    {
        public const string UserNameInput = "//input[@id='username']";
        public const string UserPassInput = "//input[@id='password']";
        public const string SignInButton = "//button[contains(@automation-id, 'sign-in')]";

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void ExecuteLogin(string login, string password)
        {
            FindElementByXPathAndSendKeys(UserNameInput, login);
            FindElementByXPathAndSendKeys(UserPassInput, password);
            FindElementByXPathAndClick(SignInButton);
        }
    }
}
