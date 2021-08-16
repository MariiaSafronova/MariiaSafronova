using TestKaspersky.PageObjects;
using NUnit.Framework;
using Aquality.Selenium.Browsers;
using TestKaspersky.Utils;
using System.Collections.Generic;

namespace TestKaspersky.Test
{
    public class TestReceiveLink: BaseTest
    {
        AuthorizationForm Authorization = new AuthorizationForm();
        MenuForm MenuForm = new MenuForm();
        DownloadPage DownloadPage = new DownloadPage();
            
        [Test, TestCaseSource(nameof(TestCases))]
        public void Test(string OS, string product)
        {
            AqualityServices.Logger.Info("Do Athorization");
            Authorization.DoAutorization();
            AqualityServices.Logger.Info("Go to Downloads Page");
            MenuForm.ClickDownloadButton();
            AqualityServices.Logger.Info("Send download link to email");
            DownloadPage.SendToEmail(OS, product);
            AqualityServices.Logger.Info("Checking receiving email message with link");
            Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() => WorkWithMail.IfMessageReceived()), "Link is not received");
        }

        static object[] TestCases =
        {
        new object[] { $"{WorkWithJson.JsonToTestData().os[0]}", $"{WorkWithJson.JsonToTestData().product[1]}" },
        new object[] { $"{WorkWithJson.JsonToTestData().os[1]}", $"{WorkWithJson.JsonToTestData().product[2]}" },
        new object[] { $"{WorkWithJson.JsonToTestData().os[3]}", $"{WorkWithJson.JsonToTestData().product[0]}" }
        };
    }
}
