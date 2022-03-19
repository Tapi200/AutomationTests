using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;


namespace PlanitAutomationTesting.UIPages
{

    public class HomePage
    {
        #region Elements
        public IWebDriver driver;
        //HomeElements
        private readonly By home = By.Id("nav-home");
        private readonly By contact = By.Id("nav-contact");
        private readonly By shop = By.Id("nav-shop");
        private readonly By cart = By.Id("nav-cart");

        //ContactPageElements
        private readonly By txtForename = By.Id("forename");
        private readonly By txtEmail = By.Id("email");
        private readonly By txtMessage = By.Id("message");
        private readonly By btnSubmit = By.LinkText("Submit");
        private readonly By forenameErr = By.Id("forename-err");
        private readonly By emailErr = By.Id("email-err");
        private readonly By messageErr = By.Id("message-err");
        private readonly By confirmationMessage = By.XPath("//div[2]/div/div");
        private readonly By btnBack = By.XPath("//a[@class='btn' and @ng-click='goBack()']");

        //ShopPageElements
        private readonly By funnyCow = By.XPath("//*[@id='product-6']/div/p/a");
        private readonly By funnyBunny = By.XPath("//*[@id='product-4']/div/p/a");

        //CartElements
        private readonly By funnyCowQuantity = By.XPath("//form/table/tbody/tr[1]/td[3]/input");
        private readonly By fluffyBunnyQuantity = By.XPath("//form/table/tbody/tr[2]/td[3]/input");

        #endregion

        #region Methods
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Navigate().GoToUrl("http://jupiter.cloud.planittesting.com");
        }
        public void CloseBrowser()
        {
            driver.Close();
        }

        public void NavigateToHomePage() => driver.FindElement(home).Click();
        public void NavigateToContactPage() => driver.FindElement(contact).Click();
        public void NavigateToShopPage() => driver.FindElement(shop).Click();
        public void NavigateToCartPage() => driver.FindElement(cart).Click();

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

        public void ClickSubmitButton() => driver.FindElement(btnSubmit).Click();

        public bool IsForenameErrorDisplayed()
        {
            return driver.FindElements(forenameErr).Count > 0 && driver.FindElement(forenameErr).Displayed;
        }

        public bool IsEmailErrorDisplayed()
        {
            return driver.FindElements(emailErr).Count > 0 && driver.FindElement(emailErr).Displayed;
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

        public int GetFunnyCowQuantity()
        {
            var funnyCowItems = driver.FindElement(funnyCowQuantity).GetAttribute("value");

            var number = Convert.ToInt32(funnyCowItems);
            return number;
        }

        public int GetFluffyBunnyQuantity()
        {
            var bunnyItems = driver.FindElement(fluffyBunnyQuantity).GetAttribute("value");
            var number = Convert.ToInt32(bunnyItems);
            return number;
        }

        #endregion

    }
}
