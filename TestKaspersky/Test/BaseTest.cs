using NUnit.Framework;
using Aquality.Selenium.Browsers;
using TestKaspersky.Utils;

namespace TestKaspersky
{
    public abstract class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            
            var browser = AqualityServices.Browser;
            browser.Maximize();
            browser.GoTo(WorkWithJson.JsonToSetting().URL);
        }

        [TearDown]
        public void Teardown()
        {
            AqualityServices.Browser.Quit();
        }
    }
}