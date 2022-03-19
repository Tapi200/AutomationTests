using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanitAutomationTesting.UIPages
{
    public class CartPage
    {
        readonly IWebDriver driver;

        private readonly By funnyCowQuantity = By.XPath("//form/table/tbody/tr[1]/td[3]/input");
        private readonly By fluffyBunnyQuantity = By.XPath("//form/table/tbody/tr[2]/td[3]/input");


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
