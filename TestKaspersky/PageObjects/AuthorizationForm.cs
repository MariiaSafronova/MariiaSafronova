using Aquality.Selenium.Forms;
using TestKaspersky.Utils;
using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;

namespace TestKaspersky
{
    public class AuthorizationForm: Form
    {
        private ITextBox EmailField => ElementFactory.GetTextBox(By.XPath("//input[@type='email']"), "Email");
        private ITextBox PasswordField => ElementFactory.GetTextBox(By.XPath("//input[@type='password']"), "Password");
        private IButton SubmitButton => ElementFactory.GetButton(By.XPath("//button[@type='submit']"), "SubmitButton");
        public AuthorizationForm(): base(By.XPath("//*[contains(@class, 'entry-panel')]"), "AuthorizationForm")
        {

        }

        public void DoAutorization()
        {
            EmailField.SendKeys(WorkWithJson.JsonToTestData().username);
            PasswordField.SendKeys(WorkWithJson.JsonToTestData().password);
            SubmitButton.Click();
        }
    }
}
