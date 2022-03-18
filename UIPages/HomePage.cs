﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace PlanitAutomationTesting.UIPages
{

    public class HomePage
    {
        IWebDriver driver;

        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Navigate().GoToUrl("http://jupiter.cloud.planittesting.com");
        }

        public void NavigateToHomePage() =>  driver.FindElement(By.Id("nav-home")).Click();

        public void NavigateToContactPage() => driver.FindElement(By.Id("nav-contact")).Click();
        
        public void NavigateToShopPage() => driver.FindElement(By.Id("nav-shop")).Click();

        public void NavigateToCartPage() => driver.FindElement(By.Id("nav-cart")).Click();

        //NavigateToContactPage
        private readonly By txtForename = By.Id("forename");
        private readonly By txtEmail = By.Id("email");
        private readonly By txtMessage = By.Id("message");
        private readonly By btnSubmit = By.LinkText("Submit");
        private readonly By forenameErr = By.Id("forename-err");
        private readonly By emailErr = By.Id("email-err");
        private readonly By messageErr = By.Id("message-err");
        //private readonly By confirmationMessage = By.ClassName("alert-success");
        //private readonly By confirmationMessage = By.XPath("//div[@class='alert-success']");
        private readonly By confirmationMessage = By.XPath("//div[2]/div/div"); //
        private readonly By btnBack = By.XPath("//a[@class='btn' and @ng-click='goBack()']");
        //private readonly By btnBack = By.LinkText("Back");
        private readonly By funnyCow = By.XPath("//*[@id='product-6']/div/p/a");
        private readonly By funnyBunny = By.XPath("//*[@id='product-4']/div/p/a");
        private readonly By funnyCowQuantity = By.XPath("//form/table/tbody/tr[1]/td[3]/input");
        private readonly By fluffyBunnyQuantity = By.XPath("//form/table/tbody/tr[2]/td[3]/input");

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

        public void BuyFluffyBunny(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                driver.FindElement(funnyBunny).Click();
            }
            
        }

        public void BuyFunnyCow(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                driver.FindElement(funnyCow).Click();
            }
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
            // var btnBackElement = driver.FindElement(btnBack);
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //IWebElement alertButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(button_xpath)));
            // alertButton.Click();

            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //var msgDetails = driver.FindElement(confirmationMessage);

            //var msgText = msgDetails.Text;

            var btnBackElement = driver.FindElement(btnBack);

            if (btnBackElement.Displayed)
            {
                return driver.FindElement(confirmationMessage).Text;
            }



            return driver.FindElement(confirmationMessage).Text;
        }

        public int GetFunnyCowQuantity()
        {
            var funnyCowItems = driver.FindElement(funnyCowQuantity).GetAttribute("value");

            var number  = Convert.ToInt32(funnyCowItems);
            return number;
        }

        public int GetFluffyBunnyQuantity()
        {
            var bunnyItems = driver.FindElement(fluffyBunnyQuantity).GetAttribute("value");
            var number = Convert.ToInt32(bunnyItems);
            return number;
        }

    }
}
