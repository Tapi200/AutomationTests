using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PlanitAutomationTesting.UIPages
{
    public class ContactPage
    {
        IWebDriver driver = new HomePage().driver;

        private readonly By txtForename = By.Id("forename");
        private readonly By txtEmail = By.Id("email");
        private readonly By txtMessage = By.Id("message");
        private readonly By btnSubmit = By.LinkText("Submit");
        private readonly By forenameErr = By.Id("forename-err");
        private readonly By emailErr = By.Id("email-err");
        private readonly By messageErr = By.Id("message-err");
        private readonly By confirmationMessage = By.XPath("//div[2]/div/div");
        private readonly By btnBack = By.XPath("//a[@class='btn' and @ng-click='goBack()']");

        public void PopulateMandatoryFieldCorrectly()
        {
            driver.FindElement(txtForename).SendKeys("Worked");
            driver.FindElement(txtEmail).SendKeys("worked.example@test.com.au");
            driver.FindElement(txtMessage).SendKeys("Your website is now easier to use");
        }

        public void PopulateMandatoryFieldIncorrectly()
        {
            driver.FindElement(txtForename).SendKeys("");
            driver.FindElement(txtEmail).SendKeys("worked.example");
            driver.FindElement(txtMessage).SendKeys("");
        }

        public void ClickSubmitButton()
        {
            driver.FindElement(btnSubmit).Click();

        }

        public bool IsForenameErrorDisplayed()
        {

            if (driver.FindElements(forenameErr).Count > 0)
                return driver.FindElement(forenameErr).Displayed;

            else
                return false;
        }

        public bool IsEmailErrorDisplayed()
        {

            if (driver.FindElements(emailErr).Count > 0)
                return driver.FindElement(emailErr).Displayed;

            else
                return false;
        }

        public bool IsMessageErrorDisplayed()
        {
            if (driver.FindElements(messageErr).Count > 0)
                return driver.FindElement(messageErr).Displayed;

            else
                return false;
        }

        public bool IsForenamePopulated() => string.IsNullOrWhiteSpace(driver.FindElement(txtForename).Text);

        public bool IsEmailPolulated() => string.IsNullOrWhiteSpace(driver.FindElement(txtEmail).Text);

        public bool IsMessagePopulated() => string.IsNullOrWhiteSpace(driver.FindElement(txtMessage).Text);

        public string GetSubmissionMessage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(driver => driver.FindElement(btnBack).Displayed);
            return driver.FindElement(confirmationMessage).Text;
        }

    }
}
