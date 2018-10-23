using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace EToro.AutomationFramework.WEB.Driver
{
    public static class SeleniumDriverBuilder
    {
        private const string ConfigFileName = "config.ini";
        private const string PropFilcontentPattern = @":\s+(.*?)$";

        private static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        /// <summary>
        /// Set appropriate driver with options
        /// </summary>
        public static IWebDriver Create()
        {
            string browserName = GetBrowserName();

            switch (browserName.ToUpper().Trim())
            {
                case "CHROME":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("test-type");
                    options.AddArguments("--start-maximized");
                    var driver = new ChromeDriver(options);
                    driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
                    return driver;

                case "FIREFOX":
                    FirefoxOptions ffOptions = new FirefoxOptions();
                    ffOptions.AddArgument("--start-maximized");
                    var ffDriver = new FirefoxDriver(ffOptions);
                    return ffDriver;

                default:
                    throw new NotImplementedException();

            }

            
        }

        private static string GetBrowserName()
        {
            string fullPathToConfig = Path.Combine(AssemblyDirectory, ConfigFileName);
            string localConfig = File.ReadAllText(fullPathToConfig);

            Regex regex = new Regex(PropFilcontentPattern);
            Match match = regex.Match(localConfig);
            if (match.Success)
                return match.Groups[1].Value.Trim();

            throw new ApplicationException("Browser should be set");
        }
    }
}
