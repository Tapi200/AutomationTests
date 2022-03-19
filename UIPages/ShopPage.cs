using OpenQA.Selenium;
using System;

namespace PlanitAutomationTesting.UIPages
{
    public class ShopPage
    {

        IWebDriver driver;

        private readonly By funnyCow = By.XPath("//*[@id='product-6']/div/p/a");
        private readonly By funnyBunny = By.XPath("//*[@id='product-4']/div/p/a");
        private readonly By funnyCowQuantity = By.XPath("//form/table/tbody/tr[1]/td[3]/input");
        private readonly By fluffyBunnyQuantity = By.XPath("//form/table/tbody/tr[2]/td[3]/input");


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
    }
}
