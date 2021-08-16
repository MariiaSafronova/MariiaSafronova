using OpenQA.Selenium;
using TestKaspersky.Utils;
using Aquality.Selenium.Forms;
using Aquality.Selenium.Elements.Interfaces;

namespace TestKaspersky.PageObjects
{
    public class MenuForm: Form
    {
        private IButton DownloadsButton => ElementFactory.GetButton(By.XPath("//*[contains(@class,'main-menu')]//*[contains(@href, 'Downloads')]"), "DownloadsButton");
        public MenuForm(): base(By.XPath($"//*[contains(@class,'menu-utility')]//*[contains(text(), '{WorkWithJson.JsonToTestData().username}')]"), "TopMenuForm")
        {

        }
           
        public void ClickDownloadButton()
        {
            DownloadsButton.ClickAndWait();
        }
    }
}
