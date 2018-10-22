using OpenQA.Selenium;

namespace EToro.AutomationFramework.WEB.Driver
{
    public static class DriverService
    {
        private static IWebDriver _driver { get; set; }

        public static IWebDriver Driver
        {
            get
            {
                if (_driver != null)
                    return _driver;
                _driver = SeleniumDriverBuilder.Create();
                return _driver;
            }
        }
    }
}
