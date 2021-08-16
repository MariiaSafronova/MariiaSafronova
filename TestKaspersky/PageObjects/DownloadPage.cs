using OpenQA.Selenium;
using TestKaspersky.Utils;
using Aquality.Selenium.Forms;
using Aquality.Selenium.Elements.Interfaces;

namespace TestKaspersky.PageObjects
{
    public class DownloadPage: Form
    {
        private IButton SelectOSButton(string OS) => ElementFactory.GetButton(By.XPath($"//*[contains(@data-at-selector, 'osName') and contains(text(), '{OS}')]"), "SelectOSButton");
        private IButton DownloadButton(string product) => ElementFactory.GetButton(By.XPath($"//*[contains(@data-at-selector, 'serviceName') and contains(text(), '{product}')]//following::button[1]"), "DownloadProductButton");
        private IButton OtherDownloadsButton => ElementFactory.GetButton(By.XPath("//button[contains(@data-at-selector, 'otherDownloads')]"), "OtherDownloadsButton");
        private IButton SendButton => ElementFactory.GetButton(By.XPath("//button[contains(@data-at-selector, 'sendToMe')]"), "SendToMeButton");
        private IButton SendToEmailButton => ElementFactory.GetButton(By.XPath("//button[contains(@data-at-selector, 'SendSelfBtn')]"), "SendToEmailButton");
        public DownloadPage(): base(By.XPath("//*[@id='trialSoft']"), "DownloadPage")
        {

        }
        
        public void SendToEmail(string OS, string product)
        {
            SelectOSButton(OS).ClickAndWait();
            DownloadButton(product).WaitAndClick();
            OtherDownloadsButton.WaitAndClick();
            SendButton.WaitAndClick();
            SendToEmailButton.WaitAndClick();
        }
    }
}
