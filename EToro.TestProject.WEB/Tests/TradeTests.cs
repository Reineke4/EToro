using System;
using EToro.AutomationFramework.WEB.Driver;
using EToro.TestProject.AutotestCommon;
using EToro.TestProject.WEB.Pages;
using NUnit.Framework;

namespace EToro.TestProject.WEB.Tests
{
    
    class TradeTests
    {
        readonly HomeScreen homeScreen = new HomeScreen(DriverService.Driver);
        readonly LoginPage loginPage = new LoginPage(DriverService.Driver);
        readonly WhatchlistsPage whatchlistsPage = new WhatchlistsPage(DriverService.Driver);
        readonly CurrencyPage currencyPage = new CurrencyPage(DriverService.Driver);
        readonly TradePage tradePage = new TradePage(DriverService.Driver);


        [OneTimeSetUp]
        public void BeforeTests()
        {
            DriverService.Driver.Navigate().GoToUrl(PermanentTestData.BaseUrl);
            homeScreen.MoveToTheLoginPage();
            loginPage.ExecuteLogin(PermanentTestData.Login, PermanentTestData.Password);
        }

        [Test]
        public void VerifyThatTheMinimumBTCValueIsTwoDollars()
        {
            whatchlistsPage.ClosePopUp();
            whatchlistsPage.ChooseCurrency(PermanentTestData.CurrencyBTC);
            currencyPage.StartTrading();
            tradePage.DecreaseCurrencyAmountToMin();
            string actualMinAmountValue = tradePage.GetMinCurrencyAmount();
            Assert.AreEqual(PermanentTestData.MinAmountValueBTC, actualMinAmountValue);
        }

        [TearDown]
        public void AfterTests()
        {
            DriverService.Driver.Quit();
        }
    }
}
